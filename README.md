# Please Return the Robot

A 2D robot-salvage game prototype built with Godot and C#. A personal project for learning the engine, with an in-game Lua terminal taking shape.

## Current state

The prototype includes player movement and jumping, a home base and salvage room, a placeholder robot, and a terminal editor with basic Lua syntax highlighting. Lua execution and programmable robot behavior are not implemented yet; the terminal's sample script is illustrative.

## Run locally

- **Godot 4.7.2 .NET** editor, matching `Godot.NET.Sdk` in the project file.
- **.NET SDK 8 or newer** to build the desktop project, which targets `net8.0`. CI uses .NET SDK 10.

1. Clone this repository.
2. From the project root, restore packages and compile:

   ```powershell
   dotnet build '.\Please Return the Robot.csproj'
   ```

3. Import `project.godot` in the Godot .NET editor and let the assets finish importing.
4. Press **F5** to run the startup scene, `world/Main.tscn`.

### Controls

| Action | Key |
| --- | --- |
| Move | A / D or Left / Right arrows |
| Jump | Space |
| Open terminal when nearby | E |
| Close terminal | Esc |

Player movement is disabled while the terminal is open.

## Project layout

| Path | Contents |
| --- | --- |
| `world/` | Startup scene, home base, salvage room, and terminal interaction |
| `player/` | Player movement |
| `robot/` | Robot scene |
| `ui/terminal/` | Terminal editor scene and syntax highlighting |
| `theme/` | Shared UI theme, world palette, and fonts |

## Development

Run the build command above after C# changes and playtest affected behavior in Godot. GitHub Actions compiles the project on pushes and pull requests; it does not playtest or export the game.

Commit source assets, `.import` metadata, and `.cs.uid` files alongside scenes and scripts. Godot's `.godot/` cache, build output, and local editor settings are ignored. Project conventions are in [AGENTS.md](AGENTS.md).

## Credits and licensing

- JetBrains Mono is bundled under the [SIL Open Font License 1.1](theme/fonts/JetBrainsMono/OFL.txt).
- LuaCSharp 0.5.8 is referenced through NuGet for the planned scripting integration.

No license has been selected for the project's own code and assets.
