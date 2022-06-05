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
            _random = new Random(); //TODO: Allow seed specification and add the seed to _name.GetHashCode()
            _flight_routes = new List<Tuple<Airport, uint>>();
        }

        public void PrintStats()
        {
            Console.WriteLine($"Statistics for Airport: {_name}.");
            Console.WriteLine($"    Total Passenger Arrivals: { _totalPassengerArrivals}.");
            Console.WriteLine($"    Total Passenger Departures: { _totalPassengerDepartures}.");
            Console.WriteLine($"    Total Aircraft Arrivals: { _totalPlaneArrivals}.");
            Console.WriteLine($"    Total Aircraft Departures: { _totalPlaneDepartures}.");
            Console.WriteLine();

        }

        public string Name { get { return _name; } }

        public void AddRoute(Airport destination, uint flight_time)
        {
            _flight_routes.Add(new Tuple<Airport, uint>(destination, flight_time));
        }

        public void ArrivalEvent(Airplane airplane)
        {
            _totalPassengerArrivals += airplane.PassengerCount;
            _totalPlaneArrivals++;

            uint delay = (uint)_random.Next(20, 40);

            // schedule this plane to prepare for next flight after passengers disembark
            Console.WriteLine($"{Simulator.Now()}: Aircraft {airplane.Name} Landed at {_name}. {airplane.PassengerCount} passengers disembarking.  Next boarding at time { Simulator.Now() + delay}");

            Simulator.Schedule(delay, this.ScheduleDepartureEvent, airplane);
        }

        public void ScheduleDepartureEvent(Airplane airplane)
        {
            // load the plane with passengers and schedule a take off
            airplane.PassengerCount = (uint)_random.Next(100, 150);
            uint delay = (uint)_random.Next(20, 30);
            Console.WriteLine($"{Simulator.Now()}: Aircraft {airplane.Name} now boarding with {airplane.PassengerCount} passengers.  Wheels up at {Simulator.Now() + delay}.");

            Simulator.Schedule(delay, this.TakeOffEvent, airplane);
        }

        public void TakeOffEvent(Airplane airplane)
        {
            if(_flight_routes.Count == 0)
            {
                throw new InvalidOperationException("Can't take off without any possible desinations");
            }

            Tuple<Airport, uint> route = _flight_routes[_random.Next(0, _flight_routes.Count)];

            Console.WriteLine($"{Simulator.Now()}: Aircraft {airplane.Name} bound to {route.Item1.Name} taking off with expected arrival time of {Simulator.Now() + route.Item2}.");

            _totalPlaneDepartures++;
            _totalPassengerDepartures += airplane.PassengerCount;

            Simulator.Schedule(route.Item2, route.Item1.ArrivalEvent, airplane);
        }

        private string _name;
        
        private Random _random;

        private uint _totalPassengerArrivals = 0;
        private uint _totalPlaneArrivals = 0;
        private uint _totalPlaneDepartures = 0;
        private uint _totalPassengerDepartures = 0;

        private List<Tuple<Airport, uint>> _flight_routes;
    }
}
