using System;
using System.Threading.Tasks;
using Lua;

namespace PleaseReturntheRobot;

public sealed class LuaProgramRunner
{
    public async Task RunAsync(string source, RobotApi robotApi)
    {
        using LuaState state = LuaState.Create();
        RegisterCommands(state, robotApi);
        await state.DoStringAsync(source);
    }

    private void RegisterCommands(LuaState state, RobotApi robotApi)
    {
        RegisterAction(state, "hatch_bot", robotApi.HatchBot);
    }

    private void RegisterAction(LuaState state, string name, Action action)
    {
        state.Environment[name] = new LuaFunction((_, _) =>
        {
            action();
            return new(0);
        });
    }
}
