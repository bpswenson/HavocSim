using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public class SimpleSimulatorImpl : ISimulatorImpl
    {
        public SimpleSimulatorImpl(IScheduler scheduler)
        {
            _stop = false;
            _uid = 0;
            _currentTime = 0;
            _eventsProcessed = 0;
            _scheduler = scheduler;
        }

        public bool IsFinished()
        {
            return _scheduler.IsEmpty() || _stop;
        }
        public void Stop()
        {
            _stop = true;
        }
        public void Stop(uint delay) { 
        }
        /*
        public Event Schedule(uint delay, IEventImpl ev)
        {
            EventKey key = new EventKey();
            key.TimeStamp = _currentTime + delay;
            key.Uid = _uid++;

            Event ret = new Event(ev, key);
            _scheduler.Insert(ret);
            return ret;
        }
        */
        public void Remove(Event ev)
        {
            _scheduler.Remove(ev);
        }
        public void Run()
        {
            if(_scheduler is null)
            {
                throw new InvalidOperationException("Attempting to run simulation with invalid scheduler (FEL)");
            }
            while(!_scheduler.IsEmpty() && !_stop)
            {
                Event next = _scheduler.RemoveNext();
                _currentTime = next.TimeStamp;
                next.Invoke();
                _eventsProcessed++;
            }
        }
        public uint Now()
        {
            return _currentTime;
        }

        public uint GetSystemId()
        {
            return 0;
        }
        
        public uint GetEventCount()
        {
            return _eventsProcessed;
        }

        public Event Schedule(uint delay, Action ev)
        {
            Event ret = new EventT(_uid++, _currentTime + delay, ev);
            _scheduler.Insert(ret);
            return ret;
        }
        public Event Schedule<T1>(uint delay, Action<T1> ev, T1 d1)
        {
            Event ret = new EventT<T1>(_uid++, _currentTime + delay, ev, d1);
            _scheduler.Insert(ret);
            return ret;
        }
        public Event Schedule<T1, T2>(uint delay, Action<T1, T2> ev, T1 d1, T2 d2)
        {
            Event ret = new EventT<T1, T2>(_uid++, _currentTime + delay, ev, d1, d2);
            _scheduler.Insert(ret);
            return ret;
        }
        public Event Schedule<T1, T2, T3>(uint delay, Action<T1, T2, T3> ev, T1 d1, T2 d2, T3 d3)
        {
            Event ret = new EventT<T1, T2, T3>(_uid++, _currentTime + delay, ev, d1, d2, d3);
            _scheduler.Insert(ret);
            return ret;
        }
        public Event Schedule<T1, T2, T3, T4>(uint delay, Action<T1, T2, T3, T4> ev, T1 d1, T2 d2, T3 d3, T4 d4)
        {
            Event ret = new EventT<T1, T2, T3, T4>(_uid++, _currentTime + delay, ev, d1, d2, d3, d4);
            _scheduler.Insert(ret);
            return ret;
        }

        /// <summary>
        ///   Flag for ending simulation
        /// </summary>
        private bool _stop;

        /// <summary>
        ///   Next event unique id
        /// </summary>
        private uint _uid;

        /// <summary>
        ///  Scheduler used for storing events
        /// </summary>
        private IScheduler _scheduler;

        /// <summary>
        ///  Current Simulation Time
        /// </summary>
        private uint _currentTime;

        /// <summary>
        ///  Count of events processed;
        /// </summary>
        private uint _eventsProcessed;
    }
}
