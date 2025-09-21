
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class DungeonLevel { public int Level; public int Monsters; public int Treasures; }
    public class DungeonExplorationSystem : ISystem
    {
        public string Name => "DungeonExploration";
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; }
        public void Tick(World world, int tick)
        {
            // Each tick has minor chance to spawn a dungeon expedition which yields loot or tech
            if (rnd!.NextDouble() < 0.002)
            {
                var c = world.Countries.Values.OrderBy(x=>rnd.Next()).First();
                c.Treasury += 20000;
                c.GDP *= 1.001;
            }
        }
    }
}
