using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (XInput == Player.FacingDirection && Player.IsWallDetected())
            return;

        if(XInput != 0 && Player.IsBusy == false)
            StateMachine.ChangeState(Player.MoveState);
    }
}

