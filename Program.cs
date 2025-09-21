
using System;
using System.IO;

namespace Extreme4X_MegaFusion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extreme4X Mega Fusion - prototype (original code inspired by many games)"); 
            int seed = 2025;
            if (args.Length>0 && int.TryParse(args[0], out var s)) seed = s;
            var engine = new Engine(seed);
            engine.SetupProceduralWorld(24); // create 24 countries for demo
            engine.Run(1000);
            Console.WriteLine("Run complete. Telemetry exported to ./output");
        }
    }
}
