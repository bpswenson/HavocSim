using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public interface IScheduler
    {
        public void Insert(Event ev);
        public bool IsEmpty();
        public Event PeekNext();
        public Event RemoveNext();
        public void Remove(Event ev);
    }
}
