using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public abstract class Scheduler
    {
        public abstract void Insert(Event ev);
        public abstract bool IsEmpty();
        public abstract Event PeekNext();
        public abstract Event RemoveNext();
        public abstract void Remove(Event ev);
    }
}
