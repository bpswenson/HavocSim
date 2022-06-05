using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSim
{
    public class Airplane
    {
        public Airplane(string name)
        {
            _name = name;
        }

    
        public string Name
        {
            get { return _name; }
        }

        public uint PassengerCount
        {
            get; set;
        }

        private string _name;

    }
}
