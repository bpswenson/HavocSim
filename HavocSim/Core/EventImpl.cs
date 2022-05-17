using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public interface IEventImpl
    {
        public void Invoke();
        public void Cancel();

    }
    // not as spiffy as variadic generics with c++ but works
    public struct Event<T1> : IEventImpl
    {
        public Event(Action<T1> ev, T1 d1) {
            _ev = ev;
            _d1 = d1;
        }
        public void Invoke()
        {
            if (_active)
            {
                _ev(_d1);
            }
        }
        public void Cancel()
        {
            _active = false;
        }
        bool _active = true;
        private Action<T1> _ev;
        private T1 _d1; 
    }

    public struct Event<T1, T2> : IEventImpl
    {
        public Event(Action<T1, T2> ev, T1 d1, T2 d2)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
        }
        public void Invoke()
        {
            if (_active) { _ev(_d1, _d2); }
        }
        public void Cancel()
        {
            _active = false;
        }
        bool _active = true;
        private Action<T1, T2> _ev;
        private T1 _d1;
        private T2 _d2;
    }

    public struct Event<T1, T2, T3> : IEventImpl
    {
        public Event(Action<T1, T2, T3> ev, T1 d1, T2 d2, T3 d3)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
            _d3 = d3;
        }
        public void Invoke()
        {
            if(_active) { _ev(_d1, _d2, _d3); }
        }
        public void Cancel()
        {
            _active = false;
        }
        bool _active = true;
        private Action<T1, T2, T3> _ev;
        private T1 _d1;
        private T2 _d2;
        private T3 _d3;
    }

    public struct Event<T1, T2, T3, T4> : IEventImpl
    {
        public Event(Action<T1, T2, T3, T4> ev, T1 d1, T2 d2, T3 d3, T4 d4)
        {
            _ev = ev;
            _d1 = d1;
            _d2 = d2;
            _d3 = d3;
            _d4 = d4;
        }
        public void Invoke()
        {
            if(_active) { _ev(_d1, _d2, _d3, _d4); }
        }
        public void Cancel()
        {
            _active = false;
        }
        bool _active = true;
        private Action<T1, T2, T3, T4> _ev;
        private T1 _d1;
        private T2 _d2;
        private T3 _d3;
        private T4 _d4;
    }
}
