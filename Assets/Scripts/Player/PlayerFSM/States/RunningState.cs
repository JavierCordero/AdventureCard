using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovingState
{
    
    public RunningState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation, PlayerInputHandler p_playerInput)
       : base(p_playerMovement, p_stateMachine,p_playerAnimation, p_playerInput)
    {
    }

    public override void Enter()
    {
        base.Enter();
        movement = false;
        run = true;
        attack = false;
        playerMovement.currentSpeed = playerMovement.startSpeed * playerMovement.speedMultiplier;
        playerAnimation.EnableRun();
        
    }

    public override void Exit()
    {
        base.Exit();
        run = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!run)
        {
            stateMachine.ChangeState(playerMovement.walkingState);
            return;
        }
        //if (jump)
        //{
        //    stateMachine.ChangeState(playerMovement.jumpingState);
        //    return;
        //}

        //if (roll)
        //{
        //    stateMachine.ChangeState(playerMovement.rollingState);
        //    return;
        //}

        if (attack)
            stateMachine.ChangeState(playerMovement.attackState);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
