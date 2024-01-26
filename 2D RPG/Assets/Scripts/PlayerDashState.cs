using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StateTimer = Player.DashDuration;

    }

    public override void Exit()
    {
        base.Exit();
        Player.SetVelocity(0, Rigidbody2D.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (!Player.IsGroundDetected() && Player.IsWallDetected())
            StateMachine.ChangeState(Player.WallSlideState);

        Player.SetVelocity(Player.DashSpeed * Player.DashDirection, 0);

        if (StateTimer < 0)
            StateMachine.ChangeState(Player.IdleState);

    }
}
