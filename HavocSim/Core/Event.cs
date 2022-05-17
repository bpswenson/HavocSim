using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public struct EventKey
    {
        public uint TimeStamp { get; set; }
        public uint Uid; 
        public uint Context;

        public bool Equals(EventKey other)
        {
            return Uid == other.Uid;
        }

        public static bool operator!=(EventKey lhs, EventKey rhs)
        {
            return lhs.Uid != rhs.Uid;
        }

        public static bool operator ==(EventKey lhs, EventKey rhs)
        {
            return lhs.Uid == rhs.Uid;
        }

        public static bool operator > (EventKey lhs, EventKey rhs)
        {
            return false;
        }

        public static bool operator < (EventKey lhs, EventKey rhs)
        {
            return false;
        }
    }

    public struct Event
    {
        public EventImpl Impl;
        public EventKey Key;
    }
}
