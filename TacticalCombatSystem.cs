
using System;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class TacticalCombatSystem : ISystem
    {
        public string Name => "TacticalCombat";
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; }
        public void Tick(World world, int tick)
        {
            // simplified: chance for small tactical engagements between random units
            if (rnd!.NextDouble() < 0.003)
            {
                var a = world.Countries.Values.OrderBy(x=>rnd.Next()).First();
                var b = world.Countries.Values.OrderBy(x=>rnd.Next()).First(c=>c.Id!=a.Id);
                // casualty simulation
                double atk = Math.Max(1, a.Units.Sum(u=>u.CombatPower()));
                double def = Math.Max(1, b.Units.Sum(u=>u.CombatPower()));
                double atkCas = atk/(atk+def) * 1000;
                double defCas = def/(atk+def) * 1000;
                a.GDP *= 1 - atkCas*1e-6; b.GDP *= 1 - defCas*1e-6;
            }
        }
    }
}
