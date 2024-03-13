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
        // Cargos -----------------------------------------------------------------

        private double INIT_CARGOs = 0;
        private double ACTUAL_CARGOs = 0;
        private double INTEGRITY_CARGOs = 0;

        private void iterateCargos()
        {
            ACTUAL_CARGOs = 0;

            foreach (IMyCargoContainer Cargo in CARGOs)
            {
                if (Cargo != null && Cargo.IsFunctional)
                {
                    ACTUAL_CARGOs+= Cargo.GetInventory().MaxVolume.RawValue;
                }
            }

            INTEGRITY_CARGOs = Math.Round(100 * (ACTUAL_CARGOs / INIT_CARGOs));
        }

        private void initCargos()
        {
            INIT_CARGOs = 0;
            foreach (IMyCargoContainer Cargo in CARGOs)
            {
                if (Cargo != null)
                    INIT_CARGOs += Cargo.GetInventory().MaxVolume.RawValue;
            }
        }
    }
}
