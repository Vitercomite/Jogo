
Extreme4X - Mega Fusion (Prototype)
==================================

Overview
--------
This project is an original, modular prototype inspired by many complex strategy, simulation, and roguelike games.
It intentionally *does not* copy proprietary code or assets. Instead it provides original implementations and many
extension points so you can create a large, highly detailed strategy title.

What I implemented here
- Engine harness with modular SystemManager that registers ~200 system stubs (AutoSystemStub_1..200) to simulate scale.
- Deep systems implemented: ProceduralGenerator, EventEngine (mass events), AdvancedBanking, OrderBookMarket, CityEconomy,
  GeoPolitics, CrimeSystem, DungeonExploration, TacticalCombat, TechTree, and more.
- ASCII & web mockups available separately in earlier package (you can integrate exported .map.json with them).
- Installer scripts (install.sh, install.bat) to copy files locally.

How to build & run
------------------
Requirements: .NET 7 SDK installed.
1. dotnet restore
2. dotnet build -c Release
3. dotnet run --project . -- 2025

This will run the harness which generates telemetry in ./output/ (telemetry CSV and state .map.json).

Legal / License
---------------
All code in this repository is original. You are free to use and adapt it. This prototype is provided under the MIT license.
You may not request or expect direct copies of proprietary game code or assets; instead we implement original systems inspired by game design patterns.

Next steps I can do for you (pick any)
- Implement deeper Austrian-school economic models (banks, interest, malinvestment, production triangles).
- Add a real order-book matching engine with limit orders, market makers, and historic price charts.
- Expand the event engine to support conditional event chains and a GUI to author events.
- Connect web UI live with WebSocket for real-time updates and interactive control.
- Add tile-based ASCII UI with layers (terrain, infrastructure, units, politics) integrated with exported .map.json.

Tell me which next step(s) you want and I will implement them.
