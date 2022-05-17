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
        public Event Schedule(uint delay, IEventImpl ev)
        {
            EventKey key = new EventKey();
            key.TimeStamp = _currentTime + delay;
            key.Uid = _uid++;

            Event ret = new Event(ev, key);
            _scheduler.Insert(ret);
            return ret;
        }
        public Event ScheduleNow(IEventImpl ev)
        {
            return Schedule(0, ev);
        }
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
                _currentTime = next.Key.TimeStamp;
                next.Impl.Invoke();
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
