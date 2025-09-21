
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class EventEngine : ISystem
    {
        public string Name => "EventEngine";
        private List<GameEvent> scheduled = new List<GameEvent>();
        private Random? rnd;
        private bool scheduledOnce = false;

        public void Initialize(World world) { rnd = world.Rng; }

        public void Tick(World world, int tick)
        {
            if (!scheduledOnce)
            {
                ScheduleMassive(world, rnd!);
                scheduledOnce = true;
            }
            var toRun = scheduled.Where(e=>e.TriggerTick==tick).ToList();
            foreach(var ev in toRun) { try { ev.Apply(world); } catch {} scheduled.Remove(ev); }
            // spontaneous minor
            if (rnd!.NextDouble() < 0.01) CreateMinor(world, tick).Apply(world);
        }

        private void ScheduleMassive(World world, Random rnd)
        {
            int events = 1500;
            int maxTick = 2000;
            var keys = new List<int>(world.Countries.Keys);
            for (int i=0;i<events;i++)
            {
                int t = rnd.Next(1, maxTick);
                int cid = keys[rnd.Next(keys.Count)];
                var ev = new GameEvent{ Name = "Event_" + i, TriggerTick = t, Severity = (EventSeverity)rnd.Next(1,5),
                    Apply = (w) => {
                        var c = w.Countries.GetValueOrDefault(cid);
                        if (c==null) return;
                        // pick random effect
                        switch(rnd.Next(0,6))
                        {
                            case 0: c.Inventory["Oil"] = c.Inventory.GetValueOrDefault("Oil",0) + rnd.Next(1000,50000); break;
                            case 1: c.Treasury += 1000000; break;
                            case 2: c.Pop.Total = Math.Max(0, c.Pop.Total - (long)(c.Pop.Total*0.001)); break;
                            case 3: c.GDP *= 1.002; break;
                            case 4: c.GDP *= 0.995; break;
                            default: c.Treasury += 50000; break;
                        }
                    }
                };
                scheduled.Add(ev);
            }
        }

        private GameEvent CreateMinor(World world, int tick)
        {
            var id = world.Countries.Keys.GetEnumerator(); id.MoveNext();
            int cid = id.Current;
            return new GameEvent{ Name = "Minor", TriggerTick = tick, Severity = EventSeverity.Low, Apply = (w) => { var c = w.Countries[cid]; c.Treasury += 1000; } };
        }
    }

    public enum EventSeverity { Low=1, Medium=2, High=3, Catastrophic=4 }
    public class GameEvent { public string Name; public int TriggerTick; public EventSeverity Severity; public Action<World> Apply; }
}
