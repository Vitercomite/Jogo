
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Extreme4X_MegaFusion
{
    public static class Telemetry
    {
        public static void Dump(World w, string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Country,GDP,Treasury,Population");
            foreach(var c in w.Countries.Values) sb.AppendLine($"{c.Name},{c.GDP},{c.Treasury},{c.Pop.Total}");
            File.WriteAllText(path, sb.ToString());
        }
    }
}
