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
        //Event Schedule(uint delay, IEventImpl ev);
        void Remove(Event ev);
        void Run();
        uint Now();
        uint GetSystemId();
        uint GetEventCount();

        Event Schedule(uint delay, Action ev);
        Event Schedule<T1>(uint delay, Action<T1> ev, T1 d1);
        Event Schedule<T1,T2>(uint delay, Action<T1,T2> ev, T1 d1, T2 d2);
        Event Schedule<T1, T2, T3>(uint delay, Action<T1, T2, T3> ev, T1 d1, T2 d2, T3 d3);
        Event Schedule<T1, T2, T3, T4>(uint delay, Action<T1, T2, T3, T4> ev, T1 d1, T2 d2, T3 d3,T4 d4);
    }
}
