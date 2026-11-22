using System;
using Godot;

namespace PleaseReturntheRobot;

public partial class GameWorld : Node2D
{
    // Node assignments
    [Export] private Player _player;
    [Export] private Camera2D _playerCamera;
    [Export] private Area2D _terminalTrigger;
    [Export] private WorkstationScreen _workstationScreen;
    [Export] private Camera2D _terminalCamera;
    [Export] private PackedScene _robotScene;
    [Export] private Marker2D _robotDock;

    private Node2D FollowedRobot { get; set; }
    private RobotApi RobotCommands { get; set; }

    private LuaProgramRunner ProgramRunner { get; } = new();

    public override void _Ready()
    {
        _workstationScreen.Close();
        _playerCamera.MakeCurrent();
        _workstationScreen.RunRequested += RunProgram;

        RobotCommands = new RobotApi(this);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("interact") && !_workstationScreen.Visible && _terminalTrigger.OverlapsBody(_player))
        {
            _player.ControlsEnabled = false;
            _workstationScreen.Open();
            _terminalCamera.MakeCurrent();
            GetViewport().SetInputAsHandled();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("close_terminal") && _workstationScreen.Visible)
        {
            _workstationScreen.Close();
            _playerCamera.MakeCurrent();
            _player.ControlsEnabled = true;
            GetViewport().SetInputAsHandled();
        }
    }

    public override void _Process(double delta)
    {
        if (!_terminalCamera.IsCurrent() || !GodotObject.IsInstanceValid(FollowedRobot))
        {
            return;
        }

        float offset = GetViewport().GetVisibleRect().Size.X
            / (4f * _terminalCamera.Zoom.X);

        _terminalCamera.GlobalPosition = new Vector2(
            FollowedRobot.GlobalPosition.X - offset,
            _terminalCamera.GlobalPosition.Y);
    }

    private async void RunProgram(string source)
    {
        try
        {
            await ProgramRunner.RunAsync(
                source,
                RobotCommands);
        }
        catch (Exception exception)
        {
            GD.PushError(exception.ToString());
        }
    }

    internal void SpawnRobotAtDock()
    {
        Node2D robot = _robotScene.Instantiate<Node2D>();
        robot.Position = ToLocal(_robotDock.GlobalPosition);
        AddChild(robot);
        FollowedRobot = robot;
    }
}
