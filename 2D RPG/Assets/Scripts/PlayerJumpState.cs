using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, Player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Rigidbody2D.velocity.y < 0)
            StateMachine.ChangeState(Player.AirState);
    }
}
