# Please Return the Robot

If `AGENTS.local.md` exists at the project root, read it before starting work for additional instructions specific to this checkout.

## Project setup

- Open the project with the Godot .NET editor. Match the Godot SDK version and .NET target declared in the C# project file.
- The startup scene is `world/Main.tscn`.

## Code structure

- Group related scenes, scripts, and resources by feature.
- Put visual styling that Godot can theme in a Godot `Theme`. Centralize world colors, materials, and other visual data outside the theme system in a `public static` class.
- Spell out the C# type wherever a declaration could use `var`, including `foreach` variables, `out` declarations, and deconstruction. Target-typed `new()` is fine when the declared type is explicit.
- Prefer Godot APIs for engine-facing work. Leave `using System;` out by default and add it explicitly when a file needs a `System` API, so the import makes that choice visible during review. Use .NET collections for data that stays in C#.
- For scene node references used only by the declaring class, prefer typed private `[Export]` fields named `_camelCase`. Assign them in the Inspector. Keep the reference when creating a node in code, and use typed `GetNode<T>()` when you need to find an existing node by path at runtime.
- For other stored state, prefer auto-properties such as `{ get; set; }`. Give the property and its setter the narrowest access they need. Use `{ get; private set; }` when callers can read the value and only the declaring class updates it.
- Use getter-only properties when a setter is unnecessary. Mark fields `readonly` when assigned only at declaration or in a constructor. Keep `[Export]` members writable so Godot can assign them from the Inspector.
- Decide per feature where game rules belong. Consider what the scene owns and what needs to run independently of it.

## Working in Godot

- Match the surrounding C# style. Use Godot's scene and theme resources for layout and shared UI styling.
- Keep `.cs.uid` files with their scripts. Use Godot's FileSystem dock for scene and resource moves so references stay intact. Keep generated `.godot/` files out of version control.

## Verification

- For C# changes, run `dotnet build '.\Please Return the Robot.csproj'` from the project root.
- Playtest the affected behavior in Godot. For UI changes, check the affected visuals and interactions, including resizing when it affects layout.
- Add focused automated tests when introducing or changing pure game rules. Agree on the initial test setup before adding a test framework.
