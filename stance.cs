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
            bool found = false;
            for (int i = 0; i < _stanceNames.Count; i++)
            {
                //Echo("? "+ stance + " == " + _stanceNames[i] + "");
                if (stance.ToLower() == _stanceNames[i].ToLower())
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

            if (_d) Echo("Setting stance '" + stance + "'.");

            _currentStance = stance;

            // update config
            setCustomData();

            // set rails
            if (_d) Echo("Setting " + RAILs.Count + " railguns to " + _stances[S][2]);
            setRails(_stances[S][2]);

            // set torps
            if (_d) Echo("Setting " + TORPs.Count + " torpedoes to " + _stances[S][0]);
            setTorpedoes(_stances[S][0]);

            // set pdcs
            if (_d) Echo("Setting " + PDCs.Count + " PDCs, " + PDCs_DEF.Count + " defence PDCs to " + _stances[S][1]);
            setPdcs(_stances[S][1]);

            // set main drives
            if (_d) Echo(
                "Setting "
                + THRUSTERs_EPSTEIN.Count + " epsteins, "
                + THRUSTERs_CHEM.Count + " chems" + " to " + _stances[S][3]);
            setMainThrusters(_stances[S][3], _stances[S][4]);

            // set RCS
            if (_d) Echo(
                "Setting "
                + THRUSTERs_RCS.Count + " rcs, "
                + THRUSTERs_ATMO.Count + " atmos" + " to " + _stances[S][11]);
            setRcsThrusters(_stances[S][11]);

            // set batteries
            if (_d) Echo("Setting " + BATTERIEs.Count + " batteries to = " + _stances[S][16]);
            setBatteries(_stances[S][16]);

            // set h2 tanks
            if (_d) Echo("Setting " + TANKs_H2.Count + " H2 tanks to stockpile = " + _stances[S][16]);
            setH2Tanks(_stances[S][16]);

            // set o2 tanks
            if (_d) Echo("Setting " + TANKs_O2.Count + " O2 tanks to stockpile = " + _stances[S][16]);
            setO2Tanks(_stances[S][16]);

            // set lighting
            if (_disableLightingControl)
            {
                if (_d) Echo("No lighting was set because lighting control is disabled.");
            }
            else
            {
                // set spotlights
                if (_d) Echo("Setting " + LIGHTs_SPOT.Count + " spotlights to " + _stances[S][5]);
                setSpotlights(_stances[S][5]);

                // set exterior lights
                if (_d) Echo("Setting " + LIGHTs_EXTERIOR.Count + " exterior lights to " + _stances[S][6]);
                Color ColourExterior = new Color(
                    _stances[S][7],
                    _stances[S][8],
                    _stances[S][9],
                    _stances[S][10]
                    );
                setExteriorLights(_stances[S][6], ColourExterior);

                // set nav lights
                if (_d) Echo("Setting " + LIGHTs_INTERIOR.Count + " exterior lights to " + _stances[S][11]);
                Color ColourInterior = new Color(
                    _stances[S][12],
                    _stances[S][13],
                    _stances[S][14],
                    _stances[S][15]
                    );
                setInteriorLights(_stances[S][11], ColourInterior);

                if (_d) Echo(
                    "Setting "
                    + LIGHTs_NAV_PORT.Count + " port nav lights, "
                    + LIGHTs_NAV_STARBOARD.Count + " starboard nav lights to " + _stances[S][6]);
                setNavLights(_stances[S][6]);

            }

            // set aux
            if (_d) Echo("Setting " + AUXILIARIEs.Count + " aux block to " + _stances[S][20]);
            setAuxiliaries(_stances[S][20]);

            // set extractors
            if (_d) Echo("Setting " + EXTRACTORs.Count + " extrators to " + _stances[S][21]);
            setExtractors(_stances[S][21]);

            // set hangar doors
            if (_d) Echo("Setting " + DOORs_HANGAR.Count + " hangar doors units to " + _stances[S][23]);
            setHangarDoors(_stances[S][23]);

            // lock doors if we're in close combat
            // 2: railguns; 0: off, 1: hold fire, 2: AI weapons free;
            if (_stances[S][2] == 2)
            {
                if (_d) Echo("Setting " + _doors.Count + " doors to locked because we are in combat (rails set to free-fire).");
                setDoorsLock("locked", "");
            }

            // colour sync for non RSM LCDs
            syncLcdColours();

            // prep pb commands

            // this one first bc it's most important.
            // 19: EFC kill; 0: no change, 1: run 'Off' on EFC.
            if (_stances[S][19] == 1)
            {
                addPbServerCommand("Off", "EFC");
                addPbServerCommand("Abort", "NavOS");
            }
            

            // 18: EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 50%, 4: 75%, 5: 100%
            if (_stances[S][18] > 0)
            {
                addPbServerCommand("Set Burn " + BURN_PERCENTAGES[_stances[S][18]], "EFC");
                addPbServerCommand("Thrust Set " + BURN_PERCENTAGES[_stances[S][18]], "NavOS");
            }


            // 17: EFC boost; 0: off, 1: on
            if (_stances[S][17] == 1)
            {
                addPbServerCommand("Boost On", "EFC");
            }
            else
            {
                addPbServerCommand("Boost Off", "EFC");
            }

            if (_d) Echo("Finished setting stance.");
        }

    }
}
