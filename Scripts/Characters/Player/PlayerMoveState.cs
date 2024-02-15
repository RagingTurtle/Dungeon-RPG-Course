using Godot;
using System;

public partial class PlayerMoveState : Node
{
        public override void _Ready()
    {
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            Player characterNode = GetOwner<Player>();
            characterNode.animationPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
