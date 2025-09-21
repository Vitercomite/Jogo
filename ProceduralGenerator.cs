
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class ProceduralGenerator : ISystem
    {
        public string Name => "ProceduralGenerator";
        private bool generated = false;
        public void Initialize(World world) { /* no-op for generator */ }
        public void Tick(World world, int tick) { /* generator runs via static Generate method */ }

        public static void Generate(World world, int seed, int countryCount)
        {
            var rnd = new Random(seed);
            world.SetRandom(rnd);
            world.Seed = seed;
            for (int i=1;i<=countryCount;i++)
            {
                var c = new Country { Id = i, Name = "Nation_" + i, GDP = Math.Round(rnd.NextDouble()*1e12,0), Treasury = Math.Round(rnd.NextDouble()*1e10,0) };
                // populate inventory resources randomly
                c.Inventory["Steel"] = rnd.Next(0,100000);
                c.Inventory["Oil"] = rnd.Next(0,80000);
                c.Inventory["Food"] = rnd.Next(1000,50000);
                // facilities
                c.Facilities.Add(new Facility{ Name = "Steel Mill" });
                c.Facilities.Add(new Facility{ Name = "Shipyard" });
                // supply nodes
                c.SupplyNetwork.Add(new SupplyNode{ Name = c.Name + "-Capital", Stock = new Dictionary<string,double>{{"Fuel", c.Inventory["Oil"]*0.5},{"Food", c.Inventory["Food"]*0.5}}});
                world.AddCountry(c);
            }
        }
    }
}
