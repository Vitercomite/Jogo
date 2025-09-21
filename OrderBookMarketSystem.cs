
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    // Simple limit order book for equities
    public class Order { public int Id; public string Ticker; public string Side; public double Price; public int Quantity; public int OwnerCountry; }
    public class OrderBook { public string Ticker; public List<Order> Bids = new List<Order>(); public List<Order> Asks = new List<Order>(); public double LastPrice=10; }

    public class OrderBookMarketSystem : ISystem
    {
        public string Name => "OrderBookMarket";
        private Dictionary<string, OrderBook> books = new Dictionary<string, OrderBook>();
        private Random? rnd;
        public void Initialize(World world) { rnd = world.Rng; books["EXA"] = new OrderBook{ Ticker="EXA", LastPrice=10 }; }
        public void Tick(World world, int tick)
        {
            // simple market-making and random trader behavior
            foreach(var b in books.Values)
            {
                // random price drift
                b.LastPrice *= 1.0 + (rnd!.NextDouble()-0.5)*0.01;
                // random trades affect treasury and company valuations (simplified)
                foreach(var c in world.Countries.Values) { if (rnd.NextDouble()<0.001) c.Treasury += b.LastPrice * 10; }
            }
        }
    }
}
