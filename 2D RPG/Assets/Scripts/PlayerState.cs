using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    protected Rigidbody2D Rigidbody2D;
    protected float XInput;
    protected float YInput;
    protected float StateTimer;
    protected bool TriggerCalled;

    private string _animatorBoolName;

    public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animatorBoolName)
    {
        Player = player;
        StateMachine = playerStateMachine;
        _animatorBoolName = animatorBoolName;
    }

    public virtual void Enter()
    {
        Player.Animator.SetBool(_animatorBoolName, true);
        Rigidbody2D = Player.Rigidbody2D;
        TriggerCalled = false;
    }

    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");
        Player.Animator.SetFloat("YVelocity", Rigidbody2D.velocity.y);
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(_animatorBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        TriggerCalled = true;
    }
}
