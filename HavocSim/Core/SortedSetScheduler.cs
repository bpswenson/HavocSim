using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public class SortedSetScheduler : IScheduler
    {
        SortedSetScheduler()
        {
            _events = new SortedSet<Event>();
        }
        public void Insert(Event ev)
        {
            _events.Add(ev);
        }
        public bool IsEmpty()
        {
            return _events.Count == 0;
        }
        public Event PeekNext()
        {
            return _events.First();
        }
        public Event RemoveNext()
        {
            Event ev = _events.First();
            _events.Remove(ev);
            return ev;
        }
        public void Remove(Event ev)
        {
            _events.Remove(ev);
        }
        private SortedSet<Event> _events;
    }
}
