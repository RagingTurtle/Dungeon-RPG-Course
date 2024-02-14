using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animationPlayerNode;
    [Export] private Sprite3D sprite3DNode;
    private Vector2 direction = new();

    public override void _Ready()
    {
        animationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD
        );

        if(direction == Vector2.Zero)
        {
            animationPlayerNode.Play(GameConstants.ANIM_IDLE);
        }
        else
        {
            animationPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
