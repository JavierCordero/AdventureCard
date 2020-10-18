using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{

    public StandingState(PlayerMovement p_playerMovement, StateMachine p_stateMachine,PlayerAnimationController p_playerAnimation) 
        : base(p_playerMovement, p_stateMachine,p_playerAnimation)
    {
      
    }

    public override void Enter()
    {
        base.Enter();
        jump = false;
        run = false;
        movement = false;
        roll = false;
        playerMovement.rb.velocity = Vector2.zero;
       playerAnimation.EnableIdle();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (jump)
        {
            stateMachine.ChangeState(playerMovement.jumpingState);
        }

        if (movement && !run)
                stateMachine.ChangeState(playerMovement.walkingState);
            else if(movement && run)
                stateMachine.ChangeState(playerMovement.runningState);
        


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }



}
