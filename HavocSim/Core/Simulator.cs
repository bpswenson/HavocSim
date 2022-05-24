using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public class Simulator
    {
        private static ISimulatorImpl? _instance;

        public static void SetImplementation(ISimulatorImpl impl)
        {
            _instance = impl;
        }
        public static ISimulatorImpl? GetImplementation() {
            return _instance;
        }
        public static bool IsFinished()
        {
            return _instance?.IsFinished() ?? true;
        }
        public static void Run()
        {
            if(_instance is null)
            {
                throw new InvalidOperationException("Attempting to run simulation without setting simulationImplementation");
            }
            _instance.Run();
        }
        public static void Stop()
        {
            _instance?.Stop();
        }
        public static void Stop(uint delay)
        {
            _instance?.Stop(delay);
        }
        public static uint GetEventCount()
        {
            return _instance?.GetEventCount() ?? 0;
        }
        public static uint Now()
        {
            return _instance?.Now() ?? 0;
        }
        public static uint GetSystemId()
        {
            return _instance?.GetSystemId() ?? 0;
        }

        public static Event? Schedule(uint delay, IEventImpl ev)
        {
            if (_instance == null)
                throw new InvalidOperationException("Unable to schedule events on a null simulation instance");

            return _instance.Schedule(delay, ev);
        }
    }
}
