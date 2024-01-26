using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
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

        Player.SetVelocity(XInput * Player.MoveSpeed, Rigidbody2D.velocity.y);

        if (XInput == 0 || Player.IsWallDetected())
            StateMachine.ChangeState(Player.IdleState);
    }
}
