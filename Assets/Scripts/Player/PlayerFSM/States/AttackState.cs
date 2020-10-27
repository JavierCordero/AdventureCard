using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation)
       : base(p_playerMovement, p_stateMachine, p_playerAnimation)
    {
    }

    public override void Enter()
    {
        if (!attack)
        {
            base.Enter();
            movement = false;
            run = false;
            attack = true;
            playerAnimation.EnableAtack(Random.Range(0, 3) + 1);
        }
    }

    public override void Exit()
    {
        base.Exit();
        attack = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (movement && !run)
            stateMachine.ChangeState(playerMovement.walkingState);
        else if (movement && run)
            stateMachine.ChangeState(playerMovement.runningState);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

       
    }
}
