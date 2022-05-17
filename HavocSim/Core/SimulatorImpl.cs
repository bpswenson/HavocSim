using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public interface ISimulatorImpl
    {
        bool IsFinished();
        void Stop();
        void Stop(uint delay);
        Event Schedule(uint delay, IEventImpl ev);
        void Remove(Event ev);
        void Run();
        uint Now();
        uint GetSystemId();
        uint GetEventCount();
    }
}
