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
    internal sealed class Profiler
    {
        public double RunningAverageMs { get; private set; }
        private double AverageRuntimeMs
        {
            get
            {
                double sum = runtimeCollection[0];
                for (int i = 1; i < BufferSize; i++)
                {
                    sum += runtimeCollection[i];
                }
                return (sum / BufferSize);
            }
        }
        /// <summary>Use <see cref="MaxRuntimeMsFast">MaxRuntimeMsFast</see> if performance is a major concern</summary>
        public double MaxRuntimeMs
        {
            get
            {
                double max = runtimeCollection[0];
                for (int i = 1; i < BufferSize; i++)
                {
                    if (runtimeCollection[i] > max)
                    {
                        max = runtimeCollection[i];
                    }
                }
                return max;
            }
        }
        public double MaxRuntimeMsFast { get; private set; }
        public double MinRuntimeMs
        {
            get
            {
                double min = runtimeCollection[0];
                for (int i = 1; i < BufferSize; i++)
                {
                    if (runtimeCollection[i] < min)
                    {
                        min = runtimeCollection[i];
                    }
                }
                return min;
            }
        }
        public int BufferSize { get; }

        private double bufferSizeInv;
        private IMyGridProgramRuntimeInfo runtimeInfo;
        private double[] runtimeCollection;
        private int counter = 0;

        /// <summary></summary>
        /// <param name="runtimeInfo">Program.Runtime instance of this script.</param>
        /// <param name="bufferSize">Buffer size. Must be 1 or higher.</param>
        public Profiler(IMyGridProgramRuntimeInfo runtimeInfo, int bufferSize = 300)
        {
            this.runtimeInfo = runtimeInfo;
            this.MaxRuntimeMsFast = runtimeInfo.LastRunTimeMs;
            this.BufferSize = MathHelper.Clamp(bufferSize, 1, int.MaxValue);
            this.bufferSizeInv = 1.0 / BufferSize;
            this.runtimeCollection = new double[bufferSize];
            this.runtimeCollection[counter] = runtimeInfo.LastRunTimeMs;
            this.counter++;
        }

        public void Run()
        {
            RunningAverageMs -= runtimeCollection[counter] * bufferSizeInv;
            RunningAverageMs += runtimeInfo.LastRunTimeMs * bufferSizeInv;

            runtimeCollection[counter] = runtimeInfo.LastRunTimeMs;

            if (runtimeInfo.LastRunTimeMs > MaxRuntimeMsFast)
            {
                MaxRuntimeMsFast = runtimeInfo.LastRunTimeMs;
            }

            counter++;

            if (counter >= BufferSize)
            {
                counter = 0;
                //Correct floating point drift
                RunningAverageMs = AverageRuntimeMs;
                MaxRuntimeMsFast = runtimeInfo.LastRunTimeMs;
            }
        }
    }
}
