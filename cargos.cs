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

        private double _initCargos = 0;
        private double _actualCargos = 0;
        private double _integrityCargos = 0;

        private void refreshCargos()
        {
            _actualCargos = 0;

            foreach (IMyCargoContainer Cargo in _cargos)
            {
                if (Cargo != null && Cargo.IsFunctional)
                {
                    _actualCargos += Cargo.GetInventory().MaxVolume.RawValue;
                }
            }

            _integrityCargos = Math.Round(100 * (_actualCargos / _initCargos));
        }

        private void initCargos()
        {
            _initCargos = 0;
            foreach (IMyCargoContainer Cargo in _cargos)
            {
                if (Cargo != null)
                    _initCargos += Cargo.GetInventory().MaxVolume.RawValue;
            }
        }
    }
}
