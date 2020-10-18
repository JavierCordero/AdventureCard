using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MovingState
{


    public WalkingState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation, PlayerInputHandler p_playerInput)
        : base(p_playerMovement, p_stateMachine, p_playerAnimation, p_playerInput)
    {
    }

    public override void Enter()
    {
        base.Enter();
        movement = true;
        run = false;
        jump = false;
        playerMovement.currentSpeed = playerMovement.startSpeed;
        playerAnimation.EnableWalk();

    }

    public override void Exit()
    {
        base.Exit();
        movement = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(movement && run)
        {
            stateMachine.ChangeState(playerMovement.runningState);
        }
        if (jump)
        {
            stateMachine.ChangeState(playerMovement.jumpingState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       

    }
}
