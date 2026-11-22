using Godot;

namespace PleaseReturntheRobot;

public partial class Player : CharacterBody2D
{
    [Export] private float WalkSpeed { get; set; } = 300f;
    [Export] private float JumpImpulse { get; set; } = 500f;

    public bool ControlsEnabled { get; set; } = true;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }
        else
        {
            velocity.Y = 0f;
        }

        float inputDir = Input.GetAxis("move_left", "move_right");
        if (ControlsEnabled)
        {
            velocity.X = inputDir * WalkSpeed;
        }
        else
        {
            velocity.X = 0f;
        }

        if (ControlsEnabled && Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = -JumpImpulse;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
