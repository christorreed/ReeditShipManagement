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
        // Projectors -----------------------------------------------------------------
        void saveProjectorPosition(IMyProjector Projector)
        {
            Projector.CustomData =

                Projector.ProjectionOffset.X + "\n" +
                Projector.ProjectionOffset.Y + "\n" +
                Projector.ProjectionOffset.Z + "\n" +

                Projector.ProjectionRotation.X + "\n" +
                Projector.ProjectionRotation.Y + "\n" +
                Projector.ProjectionRotation.Z + "\n";
        }

        void loadProjectorPosition(IMyProjector Projector)
        {
            if (!Projector.IsFunctional)
                return;

            try
            {
                string[] data = Projector.CustomData.Split('\n');
                Vector3I Offset = new Vector3I(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
                Vector3I Rotation = new Vector3I(int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]));
                // if parsed succesfully, turn it on and set the values.
                Projector.Enabled = true;
                Projector.ProjectionOffset = Offset;
                Projector.ProjectionRotation = Rotation;
                Projector.UpdateOffsetAndRotation();
            }
            catch
            {
                if (D) Echo("Failed to load projector position for " + Projector.Name);
            }
        }
    }
}
