
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extreme4X_MegaFusion
{
    public interface ISystem { string Name { get; } void Initialize(World world); void Tick(World world, int tick); }

    public class SystemManager
    {
        private readonly List<ISystem> systems = new List<ISystem>();
        public void Register(ISystem s) { systems.Add(s); }
        public void InitializeAll(World world) { foreach(var s in systems) s.Initialize(world); }
        public void TickAll(World world, int tick) { foreach(var s in systems) s.Tick(world, tick); }
    }

    // Very small generic stub to create many systems quickly
    public class AutoSystemStub : ISystem
    {
        public string Name { get; }
        public AutoSystemStub(string name) { Name = name; }
        public void Initialize(World world) { /* stub init for scale simulation */ }
        public void Tick(World world, int tick) { /* stub tick to simulate background complexity */ }
    }
}
