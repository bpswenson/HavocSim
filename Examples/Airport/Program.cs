using AirportSim;
using HavocSim.Core;

Simulator.SetImplementation(new SimpleSimulatorImpl(new SortedSetScheduler()));


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Airport atlanta = new Airport("Atlanta");
Airport milwaukee = new Airport("Milwaukee");

Airplane testPlaneOne = new Airplane();
Airplane testPlaneTwo = new Airplane();

Simulator.Schedule(20, milwaukee.Arrival, testPlaneOne);
Simulator.Schedule(30, atlanta.Arrival, testPlaneTwo);
Simulator.Run();
Console.WriteLine("Done");