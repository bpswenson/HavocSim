using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public class Simulator
    {
        private static SimulatorImpl instance = null;

        public static void SetImplementation(SimulatorImpl impl)
        {
            instance = impl;
        }
        public static SimulatorImpl GetImplementation() {
            return instance;
        }
        public static void SetScheduler(Scheduler scheduler)
        {

        }
        public static void Destroy()
        {

        }
        public static bool IsFinished()
        {
            return false;
        }
        public static void Run()
        {

        }
        public static void Stop()
        {

        }
        public static void Stop(Time delay)
        {

        }
        public static uint GetEventCount()
        {
            return 0;
        }
        public static Time Now()
        {
            return new Time();
        }
        public static uint GetSystemId()
        {
            return 0;
        }
    }
}
