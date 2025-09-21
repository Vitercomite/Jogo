
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class MilitaryUnit
    {
        public string Name = "Unit";
        public List<UnitComponent> Components = new List<UnitComponent>();
        public double Training = 0.5;
        public double Morale = 1.0;
        public double Readiness = 1.0;
        public double Manpower => Components.Sum(c=>c.Manpower);
        public double CombatPower() { return Math.Max(1, Manpower * (0.5 + Training) * Morale * Readiness); }
    }
    public class UnitComponent { public string Type="Comp"; public int Manpower=100; }
}
