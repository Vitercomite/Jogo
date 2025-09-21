
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class CriminalGroup { public string Name; public double Strength; public double Notoriety; }
    public class CrimeSystem : ISystem
    {
        public string Name => "Crime";
        private Random? rnd;
        private Dictionary<int,List<CriminalGroup>> groups = new Dictionary<int,List<CriminalGroup>>();
        public void Initialize(World world) { rnd = world.Rng; foreach(var c in world.Countries.Values) groups[c.Id] = new List<CriminalGroup>(); }
        public void Tick(World world, int tick)
        {
            foreach(var c in world.Countries.Values)
            {
                var g = groups[c.Id];
                if (rnd!.NextDouble() < 0.01) g.Add(new CriminalGroup{ Name = c.Name+" Gang "+g.Count, Strength = rnd.NextDouble()*10, Notoriety = rnd.NextDouble() });
                // crime affects treasury and stability
                if (g.Count > 0 && rnd.NextDouble() < 0.005) { c.Treasury = Math.Max(0, c.Treasury - 10000); c.Politics.Stability -= 0.001; }
            }
        }
    }
}
