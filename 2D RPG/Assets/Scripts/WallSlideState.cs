using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
    public WallSlideState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.W))
        {
            StateMachine.ChangeState(Player.WallJumpState);
            return;
        }

        if (XInput != 0 && Player.FacingDirection != XInput)
            StateMachine.ChangeState(Player.IdleState);

        if (YInput < 0)
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
        else
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y * 0.7f);

        if (Player.IsGroundDetected())
            StateMachine.ChangeState(Player.IdleState);
    }
}
