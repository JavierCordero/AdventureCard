using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingState : MovingState
{
    private float rollTimer = 0.0f;

    public RollingState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation, PlayerInputHandler p_playerInput)
        : base(p_playerMovement, p_stateMachine, p_playerAnimation, p_playerInput)
    {

    }

    public override void Enter()
    {
        base.Enter();
        movementInput = playerInput.movementInput;
        rollTimer = 0.0f;
        run = true;
        playerMovement.currentSpeed = playerMovement.startSpeed * playerMovement.speedMultiplier;
        PlayerManager.Instance.PlayerInvencible(true);
        playerAnimation.Roll();
        
    }

    public override void Exit()
    {
      
        base.Exit();
        roll = false;
        rollTimer = 0.0f;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        rollTimer += Time.deltaTime;

        float cd = 0;
        if (run)
            cd = playerMovement.rollRunCooldown;
        else
            cd = playerMovement.rollWalkCooldown;

        if (rollTimer >= cd)
        {
            roll = false;
            PlayerManager.Instance.PlayerInvencible(false);
            if (run)
                stateMachine.ChangeState(playerMovement.runningState);
            else //if (movement)
                stateMachine.ChangeState(playerMovement.walkingState);
            //else
            //    stateMachine.ChangeState(playerMovement.standingState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
