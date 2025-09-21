
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public class World
    {
        public Dictionary<int, Country> Countries { get; } = new Dictionary<int, Country>();
        private Random? rng;
        public int Seed { get; set; }
        public Random Rng => rng ?? throw new InvalidOperationException("RNG not set");

        public void SetRandom(Random r) { rng = r; }

        public void AddCountry(Country c) { Countries[c.Id] = c; c.World = this; }

        public double GetWorldGDP() { double s=0; foreach(var c in Countries.Values) s+=c.GDP; return s; }
    }

    public class Country
    {
        public int Id;
        public string Name = "Country";
        public World? World;
        public double GDP = 1e9;
        public double Treasury = 1e7;
        public Population Pop = new Population();
        public Dictionary<string,double> Inventory = new Dictionary<string,double>();
        public List<Facility> Facilities = new List<Facility>();
        public List<MilitaryUnit> Units = new List<MilitaryUnit>();
        public PoliticalProfile Politics = new PoliticalProfile();
        public List<SupplyNode> SupplyNetwork = new List<SupplyNode>();
    }

    public class Population { public long Total = 1_000_000; public double Growth = 0.01; }
    public class Facility { public string Name = "Facility"; public Dictionary<string,double> Stock = new Dictionary<string,double>(); }
    public class SupplyNode { public string Name="Node"; public Dictionary<string,double> Stock = new Dictionary<string,double>(); }
}
