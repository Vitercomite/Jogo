
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Extreme4X_MegaFusion
{
    public static class Exporter
    {
        public static void ExportState(World w, string path)
        {
            var payload = new { countries = w.Countries.Values.Select(c => new {
                id = c.Id, name = c.Name, gdp = c.GDP, treasury = c.Treasury, pop = c.Pop.Total,
                inventory = c.Inventory, facilities = c.Facilities.Select(f=>f.Name).ToArray()
            }).ToArray()};
            var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions{ WriteIndented=true });
            File.WriteAllText(path, json);
        }
    }
}
