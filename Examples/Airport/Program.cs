using AirportSim;
using HavocSim.Core;

Simulator.SetImplementation(new SimpleSimulatorImpl(new SortedSetScheduler()));


Airport atlanta = new Airport("Atlanta");
Airport denver = new Airport("Denver");
Airport milwaukee = new Airport("Milwaukee");

atlanta.AddRoute(milwaukee, 100);
milwaukee.AddRoute(atlanta, 100);
milwaukee.AddRoute(denver, 200);
denver.AddRoute(milwaukee, 150);

Airplane testPlaneOne = new Airplane("Delta 2778");
testPlaneOne.PassengerCount = 50;
Airplane testPlaneTwo = new Airplane("American Airlines 1421");
testPlaneTwo.PassengerCount = 75;

Simulator.Schedule(20, milwaukee.ArrivalEvent, testPlaneOne);
Simulator.Schedule(30, atlanta.ArrivalEvent, testPlaneTwo);
Simulator.Stop(5000);
Simulator.Run();

atlanta.PrintStats();
denver.PrintStats();
milwaukee.PrintStats();

Console.WriteLine("Done");