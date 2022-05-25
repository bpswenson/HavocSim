using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public abstract class Event : IEquatable<Event>, IComparable<Event>
    {
        public Event(uint uid, uint timestamp)
        {
            Uid = uid;
            TimeStamp = timestamp;
        }
        public abstract void Invoke();
        public void Cancel() { _active = false; }

        public bool Equals(Event? other)
        {
            if (other == null) return false;
            else if (TimeStamp == other.TimeStamp && Uid == other.Uid) return true;
            else return false;
        }

        public int CompareTo(Event? other)
        {
            if (other == null) return 1;
            else if (TimeStamp == other.TimeStamp && Uid == other.Uid) return 0;
            else return TimeStamp.CompareTo(other.TimeStamp);
        }

        public uint TimeStamp { get; }
        public uint Uid { get; }

        protected bool _active = true;
    }
    // not as spiffy as variadic generics with c++ but works

    public class EventT : Event
    {
        public EventT(uint uid, uint timestamp, Action ev) : base(uid, timestamp)
        {
            _ev = ev;
        }
        public override void Invoke()
        {
            if (_active)
            {
                _ev();
            }
        }
        private Action _ev;
    }

    public class EventT<T1> : Event
    {
        public EventT(uint uid, uint timestamp, Action<T1> ev, T1 d1) : base(uid, timestamp) {
            _ev = ev;
            _d1 = d1;
        }
        public override void Invoke() 
        {
            if (_active)
            {
                _ev(_d1);
            }
        }

        private Action<T1> _ev;
        private T1 _d1; 
    }

    public class EventT<T1, T2> : Event
    {
        public EventT(uint uid, uint timestamp, Action<T1, T2> ev, T1 d1, T2 d2) : base(uid, timestamp)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
        }
        public override void Invoke()
        {
            if (_active) { _ev(_d1, _d2); }
        }
     
        private Action<T1, T2> _ev;
        private T1 _d1;
        private T2 _d2;
    }

    public class EventT<T1, T2, T3> : Event
    {
        public EventT(uint uid, uint timestamp, Action<T1, T2, T3> ev, T1 d1, T2 d2, T3 d3) : base(uid, timestamp)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
            _d3 = d3;
        }
        public override void Invoke()
        {
            if(_active) { _ev(_d1, _d2, _d3); }
        }

        private Action<T1, T2, T3> _ev;
        private T1 _d1;
        private T2 _d2;
        private T3 _d3;
    }

    public class EventT<T1, T2, T3, T4> : Event
    {
        public EventT(uint uid, uint timestamp, Action<T1, T2, T3, T4> ev, T1 d1, T2 d2, T3 d3, T4 d4) : base(uid, timestamp)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
            _d3 = d3;
            _d4 = d4;
        }
        public override void Invoke()
        {
            if(_active) { _ev(_d1, _d2, _d3, _d4); }
        }

        private Action<T1, T2, T3, T4> _ev;
        private T1 _d1;
        private T2 _d2;
        private T3 _d3;
        private T4 _d4;
    }
}
