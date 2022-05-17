using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavocSim.Core
{
    public struct EventKey : IEquatable<EventKey>
    {
        public uint TimeStamp { get; set; }
        public uint Uid; 

        public bool Equals(EventKey other)
        {
            return Uid == other.Uid;
        }

        public static bool operator!=(EventKey lhs, EventKey rhs)
        {
            return lhs.Uid != rhs.Uid;
        }

        public static bool operator==(EventKey lhs, EventKey rhs)
        {
            return lhs.Uid == rhs.Uid;
        }

        public static bool operator > (EventKey lhs, EventKey rhs)
        {
            if(lhs.TimeStamp > rhs.TimeStamp)
            {
                return true;
            }
            else if(lhs.TimeStamp == rhs.TimeStamp && lhs.Uid > rhs.Uid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (EventKey lhs, EventKey rhs)
        {
            if(lhs.TimeStamp < rhs.TimeStamp)
            {
                return true;
            }
            else if(lhs.TimeStamp == rhs.TimeStamp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is EventKey && Equals((EventKey)obj);
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }
    }

    public class Event : IEquatable<Event>
    {
        public Event(IEventImpl impl, EventKey key)
        {
            Impl = impl;
            Key = key; 
        }

        public IEventImpl Impl;
        public EventKey Key;

        public bool Equals(Event? other)
        {
            return Key == other?.Key;
        }

        public static bool operator==(Event lhs, Event rhs)
        {
            return lhs.Key == rhs.Key;
        }
        public static bool operator !=(Event lhs, Event rhs)
        {
            return lhs.Key != rhs.Key;
        }


        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is Event && Equals((Event)obj);
        }
    }
}
