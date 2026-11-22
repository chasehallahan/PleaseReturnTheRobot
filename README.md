# Please Return the Robot

A programming and automation game about exploring abandoned ships with salvage robots. Write the routine, recover what you can, and leave enough power to get home.

## The game

Your base docks with a derelict ship. You walk over to the terminal and write Lua programs that send your robot through its rooms, searching for useful scrap and equipment. Watch the trip unfold, improve your program, and send it out again.

Getting the salvage is only part of the job. Cargo space is limited, batteries run down, and the robot needs a route back to unload and recharge. Better equipment helps, but so does a better program.

### Planned gameplay

- **Program in real Lua.** Start with a few commands and build toward loops, decisions, and reusable routines.
- **Explore room by room.** Discover what lies beyond each door in a side-on cutaway view shared by your base and the ship.
- **Automate the whole trip.** Collect salvage, manage cargo and battery reserves, return to base, and prepare for the next run.
- **Grow your operation.** Turn recovered materials into upgrades and take on procedurally generated ships of increasing size and complexity.

## Development status

The current prototype has a walkable base, a salvage room, a placeholder robot, and a terminal editor with Lua syntax highlighting. Script execution, robot automation, and the wider progression described above are still to come.

Built with Godot .NET and C#.

<details>
<summary>Run the development build</summary>

Use the **Godot 4.7.2 .NET editor** and **.NET SDK 8 or newer**. From the project root:

```powershell
dotnet build '.\Please Return the Robot.csproj'
```

Import `project.godot` in Godot, let the assets finish importing, and press **F5**.

**Controls:** A/D or arrow keys to move, Space to jump, E near the terminal to open it, and Esc to close it.

</details>

## Credits and licensing

Copyright (c) 2026 Chase Hallahan. All rights reserved. The game's original code, documentation, and assets are proprietary; see [LICENSE](LICENSE).

External providers retain their own licenses. See [third-party notices](THIRD_PARTY_NOTICES.md) for credits and license texts.
