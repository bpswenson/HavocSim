using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HavocSim.Core;

namespace AirportSim
{
    public class Airport : SimulationObject
    {
        public Airport(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }

        private string _name;
        private uint _totalPassengerArrivals = 0;
        private uint _totalPlaneArrivals = 0;
        private uint _totalPlaneDepartures = 0;
        private uint _totalPassengerDepartures = 0;

        public void Arrival(Airplane airplane)
        {
            Console.WriteLine(Simulator.Now() + ": Plane Landed at " + _name);
        }
    }
}
