
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    // Simplified bank & credit system: banks hold deposits, make loans, create credit, and can fail.
    public class Bank
    {
        public string Name;
        public double Deposits;
        public double Loans;
        public double Reserves;
        public double Capital;
        public Bank(string name, double deposits) { Name = name; Deposits = deposits; Reserves = deposits*0.1; Loans = deposits*0.6; Capital = deposits*0.3; }
    }

    public class AdvancedBankingSystem : ISystem
    {
        public string Name => "AdvancedBanking";
        private List<Bank> banks = new List<Bank>();
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; // create a bank per country
            foreach(var c in world.Countries.Values) banks.Add(new Bank(c.Name+" Bank", Math.Max(1e6, c.GDP*0.01))); }
        public void Tick(World world, int tick)
        {
            // basic credit cycle: occasionally banks expand lending, sometimes shocks reduce reserves
            foreach(var b in banks)
            {
                if (rnd!.NextDouble() < 0.02) { double newLoan = b.Deposits * 0.01; b.Loans += newLoan; b.Capital -= newLoan*0.1; }
                if (rnd!.NextDouble() < 0.005) { // shock
                    double loss = b.Loans * 0.05; b.Loans -= loss; b.Capital -= loss;
                }
                if (b.Capital < b.Deposits*0.05) { /* bank is fragile; in a complete model we'd trigger runs */ }
            }
        }
    }
}
