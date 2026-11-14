using Godot;

public partial class Main : Node2D
{
    // Node assignments
    [Export] private Player _player;
    [Export] private Camera2D _playerCamera;
    [Export] private Area2D _terminalTrigger;
    [Export] private TerminalPanel _terminalPanel;
    [Export] private Camera2D _terminalCamera;

    private Node2D FollowedRobot { get; set; }

    public override void _Ready()
    {
        _terminalPanel.Close();
        _playerCamera.MakeCurrent();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("interact") && !_terminalPanel.Visible && _terminalTrigger.OverlapsBody(_player))
        {
            _player.ControlsEnabled = false;
            _terminalPanel.Open();
            _terminalCamera.MakeCurrent();
            GetViewport().SetInputAsHandled();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("close_terminal") && _terminalPanel.Visible)
        {
            _terminalPanel.Close();
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
}
