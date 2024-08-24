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
        // these enum values need to be preserved
        // because we use those values and we don't want them minified
        // this file name has a proceeding z_ so it comes last in the file

        enum ToggleModes
        {
#region mdk preserve
Off, On, NoChange
#endregion
        }

        enum LightToggleModes
        {
#region mdk preserve
Off, On, NoChange, OnNoColourChange
#endregion
        }

        enum PdcModes
        {
#region mdk preserve
Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
#endregion
        }

        enum RailgunModes
        {
#region mdk preserve
Off, HoldFire, OpenFire, NoChange
#endregion
        }

        enum MainDriveModes
        {
#region mdk preserve
Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
#endregion
        }

        enum ManeuveringThrusterModes
        {
#region mdk preserve
Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
#endregion
        }

        enum SpotlightModes
        {
#region mdk preserve
On, Off, OnMax, NoChange
#endregion
        }

        enum TankAndBatteryModes
        {
#region mdk preserve
Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
#endregion
        }

        enum KillOrAbortNavigationModes
        {
#region mdk preserve
Abort, NoChange
#endregion
        }

        enum ExtractorModes
        {
#region mdk preserve
Off, On, FillWhenLow, KeepFull,
#endregion
        }

        enum HangarDoorModes
        {
#region mdk preserve
Closed, Open, NoChange
#endregion
        }

    }
}
