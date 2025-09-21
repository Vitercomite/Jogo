
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Extreme4X_MegaFusion
{
    public class Engine
    {
        public World World { get; } = new World();
        public SystemManager Systems { get; } = new SystemManager();
        public int Seed { get; }
        public Random Rng { get; }

        public Engine(int seed)
        {
            Seed = seed; Rng = new Random(seed);
            RegisterCoreSystems();
        }

        private void RegisterCoreSystems()
        {
            // Always register the deep systems first
            Systems.Register(new ProceduralGenerator());
            Systems.Register(new EventEngine());
            Systems.Register(new AdvancedBankingSystem());
            Systems.Register(new OrderBookMarketSystem());
            Systems.Register(new CityEconomySystem());
            Systems.Register(new GeoPoliticsSystem());
            Systems.Register(new CrimeSystem());
            Systems.Register(new DungeonExplorationSystem());
            Systems.Register(new TacticalCombatSystem());
            Systems.Register(new TechTreeSystem());
            // Register many auto-generated stubs to simulate scale
            for (int i=1;i<=200;i++)
            {
                Systems.Register(new AutoSystemStub($"SystemStub_{i}"));
            }
        }

        public void SetupProceduralWorld(int countries)
        {
            ProceduralGenerator.Generate(World, Seed, countries);
            // after generation, initialize systems with the world
            Systems.InitializeAll(World);
        }

        public void Run(int ticks)
        {
            Directory.CreateDirectory("output");
            for (int t=0;t<ticks;t++)
            {
                Systems.TickAll(World, t);
                if (t % 100 == 0) Console.WriteLine($"Tick {t} - World GDP: {World.GetWorldGDP():N0}");
            }
            // export telemetry and map
            Telemetry.Dump(World, Path.Combine("output","telemetry_run_"+Seed+".csv"));
            Exporter.ExportState(World, Path.Combine("output","state_run_"+Seed+".map.json"));
        }
    }
}
