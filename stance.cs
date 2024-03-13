using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        void setStance(string stance)
        {
            // todo
            // review this method

            bool found = false;
            for (int i = 0; i < stance_names.Count; i++)
            {
                //Echo("? "+ stance + " == " + stance_names[i] + "");
                if (stance.ToLower() == stance_names[i].ToLower())
                {
                    stance_i = i;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                ALERTS.Add(new ALERT(
                    "NO SUCH STANCE!",
                    "A command was ignored because the provided stance doens't exist. Stance names are case sensitive!"
                    , 3
                    ));
                return;
            }

            if (D) Echo("Setting stance '" + stance + "'.");

            current_stance = stance;

            updateCustomData(true);

            // set rails
            if (D) Echo("Setting " + RAILs.Count + " railguns to " + stance_data[stance_i][2]);
            setRails(stance_data[stance_i][2]);

            // set torps
            if (D) Echo("Setting " + TORPs.Count + " torpedoes to " + stance_data[stance_i][0]);
            setTorpedoes(stance_data[stance_i][0]);

            // set pdcs
            if (D) Echo("Setting " + PDCs.Count + " PDCs, " + PDCs_DEF.Count + " defence PDCs to " + stance_data[stance_i][1]);
            setPdcs(stance_data[stance_i][1]);

            // set main drives
            if (D) Echo(
                "Setting "
                + THRUSTERs_EPSTEIN.Count + " epsteins, "
                + THRUSTERs_CHEM.Count + " chems" + " to " + stance_data[stance_i][3]);
            setMainThrusters(stance_data[stance_i][3], stance_data[stance_i][4]);

            // set RCS
            if (D) Echo(
                "Setting "
                + THRUSTERs_RCS.Count + " rcs, "
                + THRUSTERs_ATMO.Count + " atmos" + " to " + stance_data[stance_i][11]);
            setRcsThrusters(stance_data[stance_i][11]);

            // set batteries
            if (D) Echo("Setting " + BATTERIEs.Count + " batteries to = " + stance_data[stance_i][16]);
            setBatteries(stance_data[stance_i][16]);

            if (D) Echo("Setting " + TANKs_H2.Count + " H2 tanks to stockpile = " + stance_data[stance_i][16]);
            setH2Tanks(stance_data[stance_i][16]);

            if (D) Echo("Setting " + TANKs_O2.Count + " O2 tanks to stockpile = " + stance_data[stance_i][16]);
            setO2Tanks(stance_data[stance_i][16]);

            // set lighting
            if (DISABLE_LIGHTING)
            {
                if (D) Echo("No lighting was set because lighting control is disabled.");
            }
            else
            {
                // set spotlights
                if (D) Echo("Setting " + LIGHTs_SPOT.Count + " spotlights to " + stance_data[stance_i][5]);
                setSpotlights(stance_data[stance_i][5]);

                // set exterior lights
                if (D) Echo("Setting " + LIGHTs_EXTERIOR.Count + " exterior lights to " + stance_data[stance_i][6]);
                Color ColourExterior = new Color(
                    stance_data[stance_i][7],
                    stance_data[stance_i][8],
                    stance_data[stance_i][9],
                    stance_data[stance_i][10]
                    );
                setExteriorLights(stance_data[stance_i][6], ColourExterior);

                // set nav lights
                if (D) Echo("Setting " + LIGHTs_INTERIOR.Count + " exterior lights to " + stance_data[stance_i][11]);
                Color ColourInterior = new Color(
                    stance_data[stance_i][12],
                    stance_data[stance_i][13],
                    stance_data[stance_i][14],
                    stance_data[stance_i][15]
                    );
                setInteriorLights(stance_data[stance_i][11], ColourInterior);

                if (D) Echo(
                    "Setting "
                    + LIGHTs_NAV_PORT.Count + " port nav lights, "
                    + LIGHTs_NAV_STARBOARD.Count + " starboard nav lights to " + stance_data[stance_i][6]);
                setNavLights(stance_data[stance_i][6]);

            }

            if (D) Echo("Setting " + AUXILIARIEs.Count + " aux block to " + stance_data[stance_i][20]);
            setAuxiliaries(stance_data[stance_i][20]);


            if (D) Echo("Setting " + EXTRACTORs.Count + " extrators to " + stance_data[stance_i][21]);
            setExtractors(stance_data[stance_i][21]);


            if (D) Echo("Setting " + DOORs_HANGAR.Count + " hangar doors units to " + stance_data[stance_i][23]);
            setHangarDoors(stance_data[stance_i][23]);

            // lock doors if we're in close combat
            // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
            if (stance_data[stance_i][2] == 2)
            {
                if (D) Echo("Setting " + DOORs.Count + " doors to locked because we are in combat (rails set to free-fire).");
                setDoorsLock("locked", "");
            }

            // colour sync for non RSM LCDs
            syncLcdColours();



            // todo
            // redo server integration
            // spread over more than one tick
            // also build NavOS integration

            /*
            if (D) Echo("Setting " + serversEfc.Count + " [EFC] servers to boost = " + stance_data[stance_i][17]
                );
            for (int i = 0; i < serversEfc.Count; i++)
            {
                if (serversEfc[i].IsFunctional && serversEfc[i].CustomName.Contains(SHIP_NAME))
                {

                    // 17: EFC boost; 0: off, 1: on
                    if (stance_data[stance_i][17] == 1)
                        runProgramable(serversEfc[i], "Boost On");
                    else
                        runProgramable(serversEfc[i], "Boost Off");

                    // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                    if (stance_data[stance_i][18] > 0)
                    {
                        runProgramable(serversEfc[i], "Set Burn " + BURN_PERCENTAGES[stance_data[stance_i][18]]);
                    }


                    // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                    if (stance_data[stance_i][19] == 1)
                        runProgramable(serversEfc[i], "Off");
                }
            }
            */

            if (D) Echo("Finished setting stance.");
        }

    }
}
