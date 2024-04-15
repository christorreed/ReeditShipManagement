using EmptyKeys.UserInterface.Generated.ActiveContractsView_Bindings;
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
    partial class Program : MyGridProgram
    {

        /*
        string[] STANCE_DATA_OUT_TOGGLE = new string[] { " OFF", "  ON", "  ON", "  ON", "  ON" }; // extras are there to cover old custom data.
        string[] STANCE_DATA_OUT_MAINTHRUST = new string[] { " OFF", "  ON", " MIN" };
        string[] STANCE_DATA_OUT_RCS = new string[] { " OFF", "  ON", "NFWD", "NREV" };
        string[] STANCE_DATA_OUT_RAILS = new string[] { " OFF", "HOLD", "FREE" };
        string[] STANCE_DATA_OUT_PDCS = new string[] { " OFF", "MDEF", " DEF", " CQB", "  ON" };
        string[] STANCE_DATA_OUT_TANKS = new string[] { "AUTO", "STOC", " AUTO" };
        string[] STANCE_DATA_OUT_BATTS = new string[] { " AUTO", "CHG", " DCHG" };
        */


        class RsmLcd
        {
            public IMyTextPanel Block;

            public bool ShowHeader = true;
            public bool ShowHeaderOverlay = false;
            public bool ShowWarnings = false;
            public bool ShowPowerAndTanks = true;
            public bool ShowInventory = true;
            public bool ShowThrust = true;
            public bool ShowIntegrity = false;
            public bool ShowAdvancedThrust = false;
        }

        // alerts appear at the top of the warnings screen
        // they are temporary messages which will be cleared at LIFETIME = 0;
        class Alert
        {
            public string
                Message,
                LongMessage;

            public int 
                Priority, // 0 lowest, 3 highest.
                Lifetime;

            public Alert(string msg, string longMsg, int pri = 0, int life = 20)
            {
                if (msg.Length > _lcdTextWidth - 3)
                    msg = msg.Substring(0, _lcdTextWidth - 3);

                Message = msg.PadRight(_lcdTextWidth - 3);
                LongMessage = longMsg;
                Priority = pri;
                Lifetime = life;
            }
        }

        // list of current alerts
        List<Alert> _alerts = new List<Alert>();

        class StatusLight
        {
            public string
                MainOutput,
                OverlayOutput;

            public StatusLight(string Name, int Status, int Step)
            {
                string blank = "    ";

                while (Step > 3)
                {
                    Step -= 4;
                }
                            
                if (Status == 0) // nominal
                {
                    MainOutput = "║ " + Name.PadRight(4) + " ║";
                    OverlayOutput = "  " + blank + "  ";
                } 
                else if (Status == 1) // warning
                {
                    if (Step == 0 || Step == 2) MainOutput = "║─" + Name.PadRight(4) + " ║";
                    else MainOutput = "║ " + Name.PadRight(4) + "─║";
                    OverlayOutput = " ░" + blank + "░ ";
                }
                else if (Status == 2) // danger
                {
                    if (Step == 0 || Step == 2)
                    {
                        MainOutput = "║ " + Name.PadRight(4) + "═║";
                        OverlayOutput = "║▒" + blank + "░║";
                    }
                    else/* if (Step == 1)*/
                    {
                        MainOutput = "║═" + Name.PadRight(4) + " ║";
                        OverlayOutput = "║░" + blank + "▒║";
                    }
                }
                else if (Status == 3) // critcal
                {

                    if (Step == 0 || Step == 2)
                    {
                        MainOutput = "║!" + Name.PadRight(4) + "!║";
                        OverlayOutput = "║▓" + blank + "▓║";
                    }
                    else /*if (Step == 1)*/
                    {
                        MainOutput = "║ " + blank + " ║";
                        OverlayOutput = "║!" + Name.PadRight(4) + "!║";

                    }
                }
            }
        }

        // todo make this configurable
        // colour of the overlay lcd text
        Color _lcdOverlayColour = new Color(255, 116, 33, 255);

        // target width of LCD text
        const int _lcdTextWidth = 32;

         // you spin me right round baby
        int _stepSpinner = 0;

        string[]
            // shown on the header lcd
            _spinnerSteps = new string[] { "▄ ", " ▄", " ▀", "▀ " },

            // shown in section headers
            _spinnerStepsBasic = new string[] { "─", "\\", "│", "/" },

            // prefix on warnings screen
            _alertPriorityStrings = new string[] { "- ", "= ", "x ", "! " };

        // strings that I'm building once
        // rather than building them over and over again each time.
        // some of these are modified, built below at buildRepeatingStrings()

        string
            // booting string
            // shown on every screen at boot
            _bootingString = "RSM is booting...\n\n",

            // the distance between spinners on the overlay
            _overlayBlank,

            // bottom of a section
            _lcdDivider,

            _headerEnd = "──\n\n",

            // status light bits
            _statusLightTop = "╔══════╗",
            _statusLightBottom = "╚══════╝",

            // div used in configs
            _configDiv,

            // headers
            _headerInventory,
            _headerThrust,
            _headerPowerAndTanks,
            _headerWarnings,
            _headerIntegrity,
            _headerAdvancedThrust,

            // value keys
            _keyVelocity, _keyMaxVelocity, _keyMass,
            _keyMaxAccel, _keyActualAccel, _keyBestAccel,
            _keyMaxThrust, _keyActualThrust,
            _keyDampDecel, _keyActualDecel,

            // bar keys
            _barKeyH2, _barKeyO2, _barKeyBatt, _barKeyCap;


        // this is run once at Program()
        // builds some strings once
        // that we will use many times later
        void buildRepeatingStrings()
        {
            // build the status light strings
            _statusLightTop = _statusLightTop + _statusLightTop + _statusLightTop + _statusLightTop + "\n";
            _statusLightBottom = _statusLightBottom + _statusLightBottom + _statusLightBottom + _statusLightBottom + "\n";

            // misc stuff
            _overlayBlank = new String(' ', _lcdTextWidth - 8);
            _lcdDivider = "└" + new String('─', _lcdTextWidth - 2) + "┘";
            _configDiv = new String('-', 26) + "\n";

            // build the lcd section headers
            // these will have spinner appended later.
            _headerInventory = buildSectionHeader("Inventory");
            _headerThrust = buildSectionHeader("Thrust");
            _headerPowerAndTanks = buildSectionHeader("Power & Tanks");
            _headerWarnings = buildSectionHeader("Warnings");
            _headerIntegrity = buildSectionHeader("Subsystem Integrity");
            _headerAdvancedThrust = buildSectionHeader("Telemetry & Thrust");

            // build the value keys
            // these are used in a few sections
            // before values
            _keyVelocity = buildValueKey("Velocity");
            _keyMaxVelocity = buildValueKey("Velocity (Max)");
            _keyMass = buildValueKey("Mass");
            _keyMaxAccel = buildValueKey("Max Accel");
            _keyActualAccel = buildValueKey("Actual Accel");
            _keyBestAccel = buildValueKey("Accel (Best)");
            _keyMaxThrust = buildValueKey("Max Thrust");
            _keyActualThrust = buildValueKey("Actual Thrust");
            _keyDampDecel = buildValueKey("Decel (Dampener)");
            _keyActualDecel = buildValueKey("Decel (Actual)");

            // build the bar keys
            // these are used before bars
            _barKeyH2 = buildBarKey("Fuel");
            _barKeyO2 = buildBarKey("Oxygen");
            _barKeyBatt = buildBarKey("Battery");
            _barKeyCap = buildBarKey("Capacity");
        }

        string buildSectionHeader(string sectionName)
        {
            // "──┤ Sec ├────────────────────";
            return "──┤ " + sectionName + " ├" + new String('─', _lcdTextWidth - 9 - sectionName.Length);
        }

        string buildValueKey(string valueName)
        {
            // "\nKey:             ";
            return "\n" + valueName + ":" + new String(' ', _lcdTextWidth - 16 - valueName.Length);
        }

        string buildBarKey(string barName)
        {
            // "Key       ["
            return barName + new String(' ', _lcdTextWidth - 22 - barName.Length) + "[";
        }

        void refreshLcds()
        {
            // spinners ----------------------------------------------

            _stepSpinner++;
            if (_stepSpinner >= _spinnerSteps.Length) _stepSpinner = 0;

            int stepOverlay = _stepSpinner + 2;
            if (stepOverlay > 3) stepOverlay -= 4;

            string spinner = _spinnerSteps[_stepSpinner];
            string basicSpinner = _spinnerStepsBasic[_stepSpinner];
            string overlaySpinner = _spinnerSteps[stepOverlay];

            // build sections ----------------------------------------------

            string sectionInventory = _headerInventory + basicSpinner + _headerEnd;
            string sectionThrust = _headerThrust + basicSpinner + _headerEnd;
            string sectionPowerAndTanks = _headerPowerAndTanks + basicSpinner + _headerEnd;
            string sectionWarnings = _headerWarnings + basicSpinner + _headerEnd;
            string sectionIntegrity = _headerIntegrity + basicSpinner + _headerEnd;
            string sectionAdvancedThrust = _headerAdvancedThrust + basicSpinner + _headerEnd;

            string sectionHeader =
                 centreText(_shipName.ToUpper(), _lcdTextWidth) + "\n" +
                 "  " + spinner + " " + centreText(_currentStanceName, _lcdTextWidth - 10) + " " + spinner + "  \n";

            string sectionHeaderOverlay =
                "\n  " + overlaySpinner + _overlayBlank + overlaySpinner + "  \n\n";


            // handle script still booting ----------------------------------------------

            if (_isBooting)
            {
                sectionInventory += _bootingString;
                sectionThrust += _bootingString;
                sectionPowerAndTanks += _bootingString;
                sectionWarnings += _bootingString;
                sectionIntegrity += _bootingString;
            }

            // handle not booting (normal ops) ----------------------------------------------

            else // we are not booting
            {
                // telemetry  ----------------------------------------------

                // update the mass and velocity of the grid
                updateTelemetry();

                double
                    // telemetry
                    accelDueToGrav = 9.81,
                    vel = Math.Round(_shipVelocity),
                    accelMax = Math.Round((_maxThrust / _shipMass / accelDueToGrav), 2),
                    accelActual = Math.Round((_actualThrust / _shipMass / accelDueToGrav), 2),

                    // power
                    initPower = Math.Round(_initReactors + _initBatteries, 1),
                    maxPowerNice = Math.Round(_maxPower, 1),

                    // tanks and batteries
                    o2Percentage = Math.Round(100 * (ACTUAL_O2 / TOTAL_O2)),
                    battPercentage = Math.Round(100 * (_actualBatteries / _totalBatteries)),
                    capPercentage = Math.Round(100 * (maxPowerNice / initPower));

                string
                    velMsg = _keyVelocity,
                    thrustUnit = " Gs";

                if (vel < 1) // if velocity is close to zero, use 500m/s instead.
                {
                    vel = 500;
                    velMsg = _keyMaxVelocity;
                }

                if (_isWeirdAboutThrustLikeGerm)
                {
                    accelDueToGrav = 1;
                    thrustUnit = " m/s/s";
                }

                // build inventory section ----------------------------------------------

                foreach (Item Item in _items)
                {
                    if (Item.InitQty != 0)
                    {
                        Item.Percentage = (100 * ((double)Item.ActualQty / (double)Item.InitQty));
                        string val = (Item.ActualQty + "/" + Item.InitQty).PadLeft(9);
                        if (val.Length > 9) val = val.Substring(0, 9);
                        sectionInventory += Item.LcdName + " [" + generateBar(Item.Percentage) + "] " + val + "\n";
                    }
                }
                sectionInventory += "\n";

                // build thrust section ----------------------------------------------

                // if we're burning
                if (_actualThrust > 0)
                    // show actual accel/decel
                    sectionThrust =
                        _keyActualDecel + stopDistance(_actualThrust, vel) +
                        _keyActualAccel + (accelActual + thrustUnit).PadLeft(15) + "\n\n";

                else // otherwise, if we are not burning
                    // show damp/best
                    sectionThrust =
                        _keyDampDecel + stopDistance(_maxThrust, vel, true) +
                        _keyBestAccel + (accelMax + thrustUnit).PadLeft(15) + "\n\n";

                // build tanks & batteries section ----------------------------------------------

                // calculate tanks and batteries
                _fuelPercentage = Math.Round(100 * (_actualH2 / _totalH2));

                sectionPowerAndTanks +=
                    _barKeyH2 + generateBar(_fuelPercentage) + "] " + (_fuelPercentage + " %").PadLeft(9) + "\n" +
                    _barKeyO2 + generateBar(o2Percentage) + "] " + (o2Percentage + " %").PadLeft(9) + "\n" +
                    _barKeyBatt + generateBar(battPercentage) + "] " + (battPercentage + " %").PadLeft(9) + "\n" +
                    _barKeyCap + generateBar(capPercentage) + "] " + (capPercentage + " %").PadLeft(9) + "\n" +
                    "Max Power:" + (maxPowerNice + " MW / " + initPower + " MW").PadLeft(22) + "\n\n";

                // build warnings section, status lights ----------------------------------------------

                List<Alert> lcdAlerts = new List<Alert>();
                List<StatusLight> statusLights = new List<StatusLight>();

                int status_light_spice = 0;

                // Clear out old alerts.
                for (int i = 0; i < _alerts.Count; i++)
                {
                    _alerts[i].Lifetime--;
                    if (_alerts[i].Lifetime < 1) // Alert timed out.
                        _alerts.RemoveAt(i);
                    else
                        lcdAlerts.Add(_alerts[i]);
                }

                // handle lidar
                if (!_lidarWorking)
                {
                    lcdAlerts.Add(new Alert(
                        "NO LiDAR!",
                        "No LiDARs are currently working. Ship is blind to enemy contacts at long range.",
                        2
                        ));
                }

                // handle spawns
                if (_spawnsDead)
                {
                    lcdAlerts.Add(new Alert("NO SPAWNS!", "NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!", 3));
                }

                // handle fuel
                int h2_priority = 0;
                if (_fuelPercentage < 5)
                {
                    lcdAlerts.Add(new Alert("FUEL CRITICAL!", "FUEL CRITICAL!\nFuel Level < 5%!", 3));
                    h2_priority = 3;
                }
                else if (_fuelPercentage < 25)
                {
                    lcdAlerts.Add(new Alert("FUEL LOW!", "FUEL LOW!\nFuel Level < 10%!", 2));
                    h2_priority = 2;
                }

                if (_currentStance.ExtractorMode != ExtractorModes.Off)
                {
                    if (_noSpareTanks)
                    {
                        if (h2_priority == 0) h2_priority = 1;

                        lcdAlerts.Add(new Alert(
                            "No spare fuel tanks",
                            "Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",
                            h2_priority));
                    }

                    if (_noExtractor)
                    {
                        if (h2_priority == 0) h2_priority = 1;

                        lcdAlerts.Add(new Alert(
                            "No Extractor",
                            "Cannot refuel!\nNo functional extractor!",
                            h2_priority));
                    }
                }

                statusLights.Add(new StatusLight("FUEL", h2_priority, _stepSpinner + status_light_spice));
                status_light_spice++;

                // handle oxygen
                int o2_priority = 0;
                if (o2Percentage < 5)
                {
                    lcdAlerts.Add(new Alert("OXYGEN CRITICAL!", "OXYGEN CRITICAL!\nShip O2 Level < 5%!", 3));
                    o2_priority = 3;
                }
                else if (o2Percentage < 10)
                {
                    lcdAlerts.Add(new Alert("OXYGEN LOW!", "OXYGEN LOW!\nShip O2 Level < 10%!", 2));
                    o2_priority = 2;
                }
                else if (o2Percentage < 25)
                {
                    lcdAlerts.Add(new Alert("Oxygen Low", "Oxygen Low!\nShip O2 Level < 25%!", 1));
                    o2_priority = 1;
                }

                // handle vents
                //string output_vents = (vents_sealed + "/" + vents.Count).PadLeft(15);
                if (_vents.Count > _ventsSealedCount)
                {
                    int unsealed = (_vents.Count - _ventsSealedCount);
                    o2_priority++;
                    lcdAlerts.Add(new Alert(
                        unsealed + " vents are unsealed",
                        unsealed + " vents are unsealed",
                        1));
                }

                // handle doors
                if (_doorsCountUnlocked > 0)
                {
                    lcdAlerts.Add(new Alert(
                        _doorsCountUnlocked + " doors are insecure",
                        _doorsCountUnlocked + " doors are insecure",
                        0));
                }

                // handle aux
                if (_activeAuxBlockCount > 0)
                {
                    lcdAlerts.Add(new Alert(
                        _keywordAuxBlocks + " is active (" + _activeAuxBlockCount + ")",
                        _keywordAuxBlocks + " is active (" + _activeAuxBlockCount + ")",
                        0));
                }

                statusLights.Add(new StatusLight("OXYG", o2_priority, _stepSpinner + status_light_spice));
                status_light_spice++;

                // handle power
                int power_priority = 0;
                if (_batteries.Count > 0)
                {
                    if (battPercentage < 5)
                    {
                        power_priority += 2;
                        lcdAlerts.Add(new Alert("BATTERIES CRITICAL!", "BATTERIES CRITICAL!\nBattery Level < 5%!", 2));
                    }
                    else if (battPercentage < 10)
                    {
                        power_priority += 1;
                        lcdAlerts.Add(new Alert("Batteries Low!", "Batteries Low!\nBattery Level < 10%!", 1));
                    }
                }

                if (_reactors.Count > 0)
                {
                    if (_emptyReactors > 0)
                    {
                        power_priority += 2;
                        lcdAlerts.Add(new Alert(_emptyReactors + " REACTORS NEED FUS. FUEL!", "At least one reactor needs Fusion Fuel!", 3));
                    }

                    if (_items[0].InitQty == 0) // Different error if there is no target.
                    {
                        if (_items[0].ActualQty > 0)
                        {
                            power_priority += 1;
                            lcdAlerts.Add(new Alert("No Spare Fusion Fuel!", "No spare fusion fuel detected in ships cargo!", 2));
                        }
                    }
                    else if (_items[0].Percentage < 5) // Fusion fuel below 5% of init quota.
                    {
                        power_priority += 2;
                        lcdAlerts.Add(new Alert("FUSION FUEL LEVEL CRITICAL!", "Fusion fuel level is low!", 3));
                    }
                    else if (_items[0].Percentage < 10) // Fusion fuel below 10% of init quota.
                    {
                        power_priority += 1;
                        lcdAlerts.Add(new Alert("Fusion Fuel Level Low!", "Fusion fuel level is low!", 2));
                    }
                }

                if (power_priority > 3) power_priority = 3;

                statusLights.Add(new StatusLight("POWR", power_priority, _stepSpinner + status_light_spice));
                status_light_spice++;

                int weap_priority = 0;

                if (_ammoCritical != "")
                {
                    string[] Ammos = _ammoCritical.Split('\n');
                    foreach (string Ammo in Ammos)
                    {
                        string output_ammo = Ammo;
                        if (Ammo.Length > 23) output_ammo = Ammo.Substring(0, 23);
                        output_ammo = output_ammo.ToUpper();
                        lcdAlerts.Add(new Alert("NEED " + output_ammo + "!", "NEED " + output_ammo + "!  Ammo Critical!", 3));
                    }
                    weap_priority = 3;
                }

                if (weap_priority > 3) weap_priority = 3;

                statusLights.Add(new StatusLight("WEAP", weap_priority, _stepSpinner + status_light_spice));
                status_light_spice++;

                // handle comms
                if (_commsActive)
                {

                    string output_comms = _commsMessage;
                    if (_antennas.Count > 0)
                        if (_antennas[0] != null)
                            output_comms = (_antennas[0] as IMyRadioAntenna).HudText;

                    string output_range = "";
                    if (_commsRange < 1000)
                        output_range = Math.Round(_commsRange) + "m";
                    else
                        output_range = Math.Round(_commsRange / 1000) + "km";

                    lcdAlerts.Add(new Alert(
                        "Comms (" + output_range + "): " + output_comms,
                        "Antenna(s) are broadcasting at a range of " + output_range + " with the message " + output_comms, 0));
                }

                // handle unowned
                if (_unownedBlockCount > 0)
                {
                    lcdAlerts.Add(new Alert(
                    _unownedBlockCount + " UNOWNED BLOCKS!",
                    "RSM detected " + _unownedBlockCount + " terminal blocks on this grid owned by a player with a different faction tag."
                    , 3
                    ));
                }

                // handle doors
                //string output_doors = (doors_count_closed + "/" + doors_count).PadLeft(15);
                if (_doorsCount > _doorsCountClosed)
                {
                    int open = (_doorsCount - _doorsCountClosed);
                    lcdAlerts.Add(new Alert(
                        open + " doors are open",
                        open + " doors are open",
                        0));
                }


                // sort alerts by priority.
                lcdAlerts = lcdAlerts.OrderBy(a => a.Priority).Reverse().ToList();


                if (lcdAlerts.Count < 1) sectionWarnings += "No warnings\n";
                else Echo("\n\n WARNINGS:");

                // output alerts to warnings list.
                for (int i = 0; i < lcdAlerts.Count; i++)
                {
                    sectionWarnings += _alertPriorityStrings[lcdAlerts[i].Priority] + lcdAlerts[i].Message + "\n";
                    Echo("-" + _alertPriorityStrings[lcdAlerts[i].Priority] + lcdAlerts[i].LongMessage);
                }

                sectionWarnings += "\n";

                // build Subsystem Integrity ----------------------------------------------

                string mainThrusterStance = _currentStance.MainDriveMode.ToString().ToUpper();
                if (mainThrusterStance.Length > 3) mainThrusterStance = mainThrusterStance.Substring(0, 3);

                string rcsThrusterStance = _currentStance.ManeuveringThrusterMode.ToString().ToUpper();
                if (rcsThrusterStance.Length > 3) rcsThrusterStance = rcsThrusterStance.Substring(0, 3);

                string tanksAndBatteriesStance = _currentStance.MainDriveMode.ToString().ToUpper();
                if (tanksAndBatteriesStance.Length > 3) tanksAndBatteriesStance = tanksAndBatteriesStance.Substring(0, 3);

                string pdcsStance = _currentStance.PdcMode.ToString().ToUpper();
                if (pdcsStance.Length > 3) pdcsStance = pdcsStance.Substring(0, 3);

                string torpStance = _currentStance.TorpedoMode.ToString().ToUpper();
                if (torpStance.Length > 3) torpStance = torpStance.Substring(0, 3);

                string railStance = _currentStance.RailgunMode.ToString().ToUpper();
                if (railStance.Length > 3) railStance = railStance.Substring(0, 3);

                try
                {
                    if (_initThrustMain > 0)
                        sectionIntegrity += "Epstein   [" + generateBar(_integrityThrustMain) + "] " + (_integrityThrustMain + "% ").PadLeft(5) + mainThrusterStance + "\n";
                    if (_initThrustRCS > 0)
                        sectionIntegrity += "RCS       [" + generateBar(INTEGRITY__rcsThrusters) + "] " + (INTEGRITY__rcsThrusters + "% ").PadLeft(5) + rcsThrusterStance + "\n";
                    if (_initReactors > 0)
                        sectionIntegrity += "Reactors  [" + generateBar(_integrityReactors) + "] " + (_integrityReactors + "% ").PadLeft(5) + "    \n";
                    if (_initBatteries > 0)
                        sectionIntegrity += "Batteries [" + generateBar(_integrityBatteries) + "] " + (_integrityBatteries + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                    if (_initPdcs > 0)
                        sectionIntegrity += "PDCs      [" + generateBar(_integrityPdcs) + "] " + (_integrityPdcs + "% ").PadLeft(5) + pdcsStance + "\n";
                    if (_initTorpLaunchers > 0)
                        sectionIntegrity += "Torpedoes [" + generateBar(_integrityTorpedoLaunchers) + "] " + (_integrityTorpedoLaunchers + "% ").PadLeft(5) + torpStance + "\n";
                    if (_initKinetics > 0)
                        sectionIntegrity += "Railguns  [" + generateBar(_integrityKinetics) + "] " + (_integrityKinetics + "% ").PadLeft(5) + railStance + "\n";
                    if (_initH2 > 0)
                        sectionIntegrity += "H2 Tanks  [" + generateBar(_integrityH2) + "] " + (_integrityH2 + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                    if (_initO2 > 0)
                        sectionIntegrity += "O2 Tanks  [" + generateBar(INTEGRITY_O2) + "] " + (INTEGRITY_O2 + "% ").PadLeft(5) + tanksAndBatteriesStance + "\n";
                    if (_initGyros > 0)
                        sectionIntegrity += "Gyros     [" + generateBar(_integrityGyros) + "] " + (_integrityGyros + "% ").PadLeft(5) + "    \n";
                    if (_initCargos > 0)
                        sectionIntegrity += "Cargo     [" + generateBar(_integrityCargos) + "] " + (_integrityCargos + "% ").PadLeft(5) + "    \n";
                    if (_initWelders > 0)
                        sectionIntegrity += "Welders   [" + generateBar(_integrityWelders) + "] " + (_integrityWelders + "% ").PadLeft(5) + "    \n";
                }

                catch { }


                if (_initBatteries + _initReactors + _initH2 == 0) // nothing init basically.
                    sectionIntegrity += 
                        "Run init when ship is\nfully repaired to display\nsubsystem integrity!" + "\n\n";

                // build header and overlay ----------------------------------------------

                string statusLightsMain = "";
                string statusLightsOverlay = "";

                foreach (StatusLight lt in statusLights)
                {
                    statusLightsMain += lt.MainOutput;
                    statusLightsOverlay += lt.OverlayOutput;
                }

                int overlay_status = _stepSpinner + 2;
                if (overlay_status > 3) overlay_status -= 4;

                sectionHeader += _statusLightTop + statusLightsMain + "\n" + _statusLightBottom;
                sectionHeaderOverlay += statusLightsOverlay;

                // advanced thrust ----------------------------------------------

                if (!_buildAdvancedThrust)
                {
                    sectionAdvancedThrust += "\n\n";
                }
                else
                {
                    // we are building advanced thrust.
                    if (_d) Echo("Building advanced thrust...");

                    string Basics = "";
                    if (_showBasicTelemetry)
                    {
                        Basics =
                            _keyMass + (Math.Round((_shipMass / 1000000), 2) + " Mkg").PadLeft(15) +
                             velMsg + (vel + " ms").PadLeft(15) +
                            _keyMaxAccel + (accelMax + thrustUnit).PadLeft(15) +
                            _keyActualAccel + (accelActual + thrustUnit).PadLeft(15) +
                            _keyMaxThrust + ((_maxThrust / 1000000) + " MN").PadLeft(15) +
                            _keyActualThrust + ((_actualThrust / 1000000) + " MN").PadLeft(15);
                    }

                    sectionAdvancedThrust +=
                        Basics +
                        _keyDampDecel + stopDistance(_maxThrust, vel, true) +
                        _keyActualDecel + stopDistance(_actualThrust, vel);

                    foreach (double Percent in _decelPercentages)
                    {
                        sectionAdvancedThrust += "\n" + ("Decel (" + (Percent * 100) + "%):").PadRight(17) + stopDistance((float)(_maxThrust * Percent), vel);
                    }

                    sectionAdvancedThrust += "\n\n";
                }

            } // end we are not booting

            // iterate RSM LCDs and write ----------------------------------------------

            foreach (RsmLcd lcd in _rsmLcds)
            {
                string output = "";

                /*
                if (show_header && show_header_overlay) // can't be both bro.
                    show_header = false;
                */

                Color colour = _currentStance.LcdTextColour;

                if (lcd.ShowHeader) output += sectionHeader;
                if (lcd.ShowHeaderOverlay)
                {
                    output += sectionHeaderOverlay;
                    colour = _lcdOverlayColour;
                }
                if (lcd.ShowWarnings) output += sectionWarnings;
                if (lcd.ShowPowerAndTanks) output += sectionPowerAndTanks;
                if (lcd.ShowInventory) output += sectionInventory;
                if (lcd.ShowThrust) output += sectionThrust;
                if (lcd.ShowIntegrity) output += sectionIntegrity;
                if (lcd.ShowAdvancedThrust)
                {
                    output += sectionAdvancedThrust;
                    _buildAdvancedThrust = true;
                }

                // write the output to the actual lcd.
                lcd.Block.WriteText(output, false);

                // set lcd text colour
                if (!_disableLcdColourControl)
                    lcd.Block.FontColor = colour;
                
            }
        }

        // colour sync for non RSM _allLcds
        void syncLcdColours()
        {
            if (_colourSyncLcds.Count > 0)
            {

                foreach (IMyTextPanel lcd in _colourSyncLcds)
                {
                    lcd.FontColor = _currentStance.LcdTextColour;
                }

                // do the RSM ones as well while we're at it.
                foreach (RsmLcd lcd in _rsmLcds)
                {
                    lcd.Block.FontColor = _currentStance.LcdTextColour;
                }
            }
        }

        void setHudLcd(string State, string Filter)
        {
            State = State.ToLower();
            List<IMyTextPanel> All_allLcds = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(_allLcds);

            foreach (IMyTextPanel lcd in _allLcds)
            {
                if (Filter == "" || lcd.CustomName.Contains(Filter))
                {
                    string cd = lcd.CustomData;
                    if (cd.Contains("hudlcd") && (State == "off" || State == "toggle"))
                        lcd.CustomData = cd.Replace("hudlcd", "hudXlcd");

                    if (cd.Contains("hudXlcd") && (State == "on" || State == "toggle"))
                        lcd.CustomData = cd.Replace("hudXlcd", "hudlcd");
                }
            }
        }


        // generates a fixed-width percentage bar for display
        // shows an error below 10%
        string generateBar(double percentage)
        {
            try
            {
                int ones_count = 0;
                if (percentage > 0)
                {
                    int try_this = (int)percentage / 10;
                    if (try_this > 10) return new string('=', 10);
                    if (try_this != 0) ones_count = try_this;
                }

                char zero = ' ';
                if (percentage < 10)
                {
                    if (_stepSpinner == 0)
                        return " ><    >< ";
                    if (_stepSpinner == 1)
                        return "  ><  ><  ";
                    if (_stepSpinner == 2)
                        return "   ><><   ";
                    if (_stepSpinner == 3)
                        return "<   ><   >";

                }

                string ones = new string('=', ones_count);
                string zeros = new string(zero, 10 - ones_count);
                return ones + zeros;
            }
            catch
            {
                return "# ERROR! #";
            }

        }

        // formats bars for h2/o2/batteries
        string barMe(string bar_type)
        {
            string bar;
            string val = "";
            double percentage = 0;


            switch (bar_type)
            {
                case "H2":
                    percentage = Math.Round(100 * (_actualH2 / _initH2));
                    val = percentage.ToString() + " %";
                    _fuelPercentage = percentage;
                    break;
                case "O2":
                    percentage = Math.Round(100 * (ACTUAL_O2 / _initO2));
                    val = percentage.ToString() + " %";
                    break;
                case "Battery":
                    percentage = Math.Round(100 * (_actualBatteries / _totalBatteries));
                    val = percentage.ToString() + " %";
                    break;

            }
            bar = generateBar(percentage);


            return " [" + bar + "] " + val.PadLeft(9);
        }


        // pad text on either side to centre it
        // important for hudlcd
        string centreText(string Text, int Width)
        {
            int spaces = Width - Text.Length;
            int padLeft = spaces / 2 + Text.Length;
            return Text.PadLeft(padLeft).PadRight(Width);
        }

        string stopDistance(double thrust, double speed, bool dampeners = false)
        {

            if (thrust <= 0) return ("N/A").PadLeft(15);

            if (dampeners) thrust = thrust * 1.5;

            //s = 1/2 * v ^ 2 * (m / F)
            double result = 0.5 * (Math.Pow(speed, 2) * (_shipMass / thrust));

            //t = v / (F / mass)
            double time = speed / (thrust / _shipMass);
            string unit = "m";
            if (result > 1000)
            {
                unit = "km";
                result = result / 1000;
            }

            return (Math.Round(result) + unit + " " + Math.Round(time) + "s").PadLeft(15);
        }


    }
}
