using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State
{
    public PlayerMovement playerMovement;
    public StateMachine stateMachine;
    public PlayerAnimationController playerAnimation;

    protected bool jump = false;
    protected bool run = false;
    protected bool movement = false;
    protected bool roll = false;
    protected bool attack = false;

    protected bool grounded = true;

    protected float fallMultiplier = 2.5f;
    protected float lowJumpMultiplier = 2f;


    public State(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation)
    {
        playerMovement = p_playerMovement;
        stateMachine = p_stateMachine;
        playerAnimation = p_playerAnimation;
    }
    public virtual void Enter()
    {

    }
    public virtual void HandleInput()
    {

    }
    public virtual void LogicUpdate()
    {
        //Debug.Log(String.Format("Jump: {0}, Run: {1}, Movement: {2}, Roll: {3}", jump, run, movement, roll));
    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {
        playerMovement.GetPlayerAnimationController().DisableAll();
        //playerMovement.rb.velocity = Vector2.zero;
        //layerMovement.ResetMovementValues();
        
    }

    public void AttackPressed()
    {
        attack = true;
    }

    public void JumpPressed()
    {
        jump = true;
    }
    public void RunPressed(bool pressed)
    {
        run = pressed;
    }
    public void MovePressed(bool p)
    {
        movement = p;
    }
    public void RollPressed()
    {
        roll = true;
    }

}
