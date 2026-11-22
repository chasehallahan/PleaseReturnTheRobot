using Godot;

namespace PleaseReturntheRobot;

public partial class CameraFeed : PanelContainer
{
    [Export] private SubViewport _feedViewport;

    public override void _Ready()
    {
        _feedViewport.World2D = GetViewport().World2D;
    }
}
