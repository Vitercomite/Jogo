
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class TechNode { public string Name; public double Progress; public bool Researched; public List<string> Prereqs = new List<string>(); }
    public class TechTreeSystem : ISystem
    {
        public string Name => "TechTree";
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; }
        public void Tick(World world, int tick)
        {
            foreach(var c in world.Countries.Values)
            {
                // small chance to progress on research which boosts GDP
                if (rnd!.NextDouble() < 0.01) { c.GDP *= 1.0005; }
            }
        }
    }
}
