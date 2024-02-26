using Godot;
using System;

public partial class Bomb : Node3D
{
    [Export] private AnimationPlayer playerNode;
    [Export] public int Damage { get; private set; } = 10;

    public override void _Ready()
    {
        playerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName)
    {
        if (animName == GameConstants.ANIM_EXPAND)
        {
            playerNode.Play(GameConstants.ANIM_EXPLOSION);
        }
        if (animName == GameConstants.ANIM_EXPLOSION)
        {
            QueueFree();
        }
    }

}
