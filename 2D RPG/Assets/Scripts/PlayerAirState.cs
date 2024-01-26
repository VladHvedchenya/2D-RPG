using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName) { }

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

        if (Player.IsWallDetected())
            StateMachine.ChangeState(Player.WallSlideState);

        if (Player.IsGroundDetected())
            StateMachine.ChangeState(Player.IdleState);

        if (XInput != 0)
            Player.SetVelocity(Player.MoveSpeed * XInput, Rigidbody2D.velocity.y);
    }
}
