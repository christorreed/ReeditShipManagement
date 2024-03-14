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
            for (int i = 0; i < STANCE_NAMES.Count; i++)
            {
                //Echo("? "+ stance + " == " + STANCE_NAMES[i] + "");
                if (stance.ToLower() == STANCE_NAMES[i].ToLower())
                {
                    S = i;
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

            STANCE = stance;

            updateCustomData(true);

            // set rails
            if (D) Echo("Setting " + RAILs.Count + " railguns to " + STANCES[S][2]);
            setRails(STANCES[S][2]);

            // set torps
            if (D) Echo("Setting " + TORPs.Count + " torpedoes to " + STANCES[S][0]);
            setTorpedoes(STANCES[S][0]);

            // set pdcs
            if (D) Echo("Setting " + PDCs.Count + " PDCs, " + PDCs_DEF.Count + " defence PDCs to " + STANCES[S][1]);
            setPdcs(STANCES[S][1]);

            // set main drives
            if (D) Echo(
                "Setting "
                + THRUSTERs_EPSTEIN.Count + " epsteins, "
                + THRUSTERs_CHEM.Count + " chems" + " to " + STANCES[S][3]);
            setMainThrusters(STANCES[S][3], STANCES[S][4]);

            // set RCS
            if (D) Echo(
                "Setting "
                + THRUSTERs_RCS.Count + " rcs, "
                + THRUSTERs_ATMO.Count + " atmos" + " to " + STANCES[S][11]);
            setRcsThrusters(STANCES[S][11]);

            // set batteries
            if (D) Echo("Setting " + BATTERIEs.Count + " batteries to = " + STANCES[S][16]);
            setBatteries(STANCES[S][16]);

            if (D) Echo("Setting " + TANKs_H2.Count + " H2 tanks to stockpile = " + STANCES[S][16]);
            setH2Tanks(STANCES[S][16]);

            if (D) Echo("Setting " + TANKs_O2.Count + " O2 tanks to stockpile = " + STANCES[S][16]);
            setO2Tanks(STANCES[S][16]);

            // set lighting
            if (DISABLE_LIGHTING)
            {
                if (D) Echo("No lighting was set because lighting control is disabled.");
            }
            else
            {
                // set spotlights
                if (D) Echo("Setting " + LIGHTs_SPOT.Count + " spotlights to " + STANCES[S][5]);
                setSpotlights(STANCES[S][5]);

                // set exterior lights
                if (D) Echo("Setting " + LIGHTs_EXTERIOR.Count + " exterior lights to " + STANCES[S][6]);
                Color ColourExterior = new Color(
                    STANCES[S][7],
                    STANCES[S][8],
                    STANCES[S][9],
                    STANCES[S][10]
                    );
                setExteriorLights(STANCES[S][6], ColourExterior);

                // set nav lights
                if (D) Echo("Setting " + LIGHTs_INTERIOR.Count + " exterior lights to " + STANCES[S][11]);
                Color ColourInterior = new Color(
                    STANCES[S][12],
                    STANCES[S][13],
                    STANCES[S][14],
                    STANCES[S][15]
                    );
                setInteriorLights(STANCES[S][11], ColourInterior);

                if (D) Echo(
                    "Setting "
                    + LIGHTs_NAV_PORT.Count + " port nav lights, "
                    + LIGHTs_NAV_STARBOARD.Count + " starboard nav lights to " + STANCES[S][6]);
                setNavLights(STANCES[S][6]);

            }

            if (D) Echo("Setting " + AUXILIARIEs.Count + " aux block to " + STANCES[S][20]);
            setAuxiliaries(STANCES[S][20]);


            if (D) Echo("Setting " + EXTRACTORs.Count + " extrators to " + STANCES[S][21]);
            setExtractors(STANCES[S][21]);


            if (D) Echo("Setting " + DOORs_HANGAR.Count + " hangar doors units to " + STANCES[S][23]);
            setHangarDoors(STANCES[S][23]);

            // lock doors if we're in close combat
            // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
            if (STANCES[S][2] == 2)
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
            if (D) Echo("Setting " + serversEfc.Count + " [EFC] servers to boost = " + STANCES[S][17]
                );
            for (int i = 0; i < serversEfc.Count; i++)
            {
                if (serversEfc[i].IsFunctional && serversEfc[i].CustomName.Contains(SHIP_NAME))
                {

                    // 17: EFC boost; 0: off, 1: on
                    if (STANCES[S][17] == 1)
                        runProgramable(serversEfc[i], "Boost On");
                    else
                        runProgramable(serversEfc[i], "Boost Off");

                    // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
                    if (STANCES[S][18] > 0)
                    {
                        runProgramable(serversEfc[i], "Set Burn " + BURN_PERCENTAGES[STANCES[S][18]]);
                    }


                    // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
                    if (STANCES[S][19] == 1)
                        runProgramable(serversEfc[i], "Off");
                }
            }
            */

            if (D) Echo("Finished setting stance.");
        }

    }
}
