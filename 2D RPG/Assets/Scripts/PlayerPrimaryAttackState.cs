using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int _comboCounter;
    private float _lastTimeAttacked;
    private float _comboWindow = 2;

    public PlayerPrimaryAttackState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName) : base(player, playerStateMachine, animatorBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();


        if (_comboCounter > 2 || Time.time >= _lastTimeAttacked + _comboWindow)
            _comboCounter = 0;

        Player.Animator.SetInteger("ComboCounter", _comboCounter);

        float attackDirection = Player.FacingDirection;

        if (XInput != 0)
            attackDirection = XInput;

        Player.SetVelocity(Player.AttackMovoment[_comboCounter] * attackDirection, Rigidbody2D.velocity.y);

        StateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        Player.StartCoroutine("BusyFor", 0.15f);

        _comboCounter++;
        _lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (StateTimer < 0)
            Player.ZeroVelocity();

        if (TriggerCalled)
            StateMachine.ChangeState(Player.IdleState);
    }
}
