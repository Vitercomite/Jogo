
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class City { public string Name; public int Population; public double GDP; public Dictionary<string,double> Services = new Dictionary<string,double>(); }
    public class CityEconomySystem : ISystem
    {
        public string Name => "CityEconomy";
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; }
        public void Tick(World world, int tick)
        {
            // For each country add small city growth and service consumption
            foreach(var c in world.Countries.Values)
            {
                // simple city growth proxy
                if (rnd!.NextDouble() < 0.05)
                {
                    c.GDP *= 1.001;
                    c.Pop.Total = (long)(c.Pop.Total * (1 + rnd.NextDouble()*0.001));
                }
            }
        }
    }
}
