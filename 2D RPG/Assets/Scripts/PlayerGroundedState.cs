using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
            StateMachine.ChangeState(Player.PrimaryAttack);

        if (Player.IsGroundDetected() == false)
            StateMachine.ChangeState(Player.AirState);

        if (Input.GetKeyDown(KeyCode.W) && Player.IsGroundDetected())
            StateMachine.ChangeState(Player.JumpState);
    }
}
