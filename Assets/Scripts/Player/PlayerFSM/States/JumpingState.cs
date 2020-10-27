using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState //: State
{
 
  
    private float delay = 0.5f;
    private float delayTimer = 0.0f;

    //public JumpingState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, PlayerAnimationController p_playerAnimation)
    //    : base(p_playerMovement, p_stateMachine,p_playerAnimation)
    //{
    //}

    //public override void Enter()
    //{
    //    base.Enter();
    //    grounded = false;
    //    delayTimer = 0.0f;
    //    playerAnimation.EnableJump();
    //    playerMovement.rb.velocity += new Vector3(0, Vector3.up.y * playerMovement.jumpForce, 0);
       

    //}

    //public override void Exit()
    //{
    //    base.Exit();
    //    grounded = true;
    //    jump = false;
    //}

    //public override void HandleInput()
    //{
    //    base.HandleInput();
    //}

    //public override void LogicUpdate()
    //{
    //    base.LogicUpdate();
    //    delayTimer += Time.deltaTime;
    //    if (grounded)
    //    {
    //        if (movement)
    //        {
    //            if (run)
    //                stateMachine.ChangeState(playerMovement.runningState);
    //            else
    //                stateMachine.ChangeState(playerMovement.walkingState);
    //        }

    //        else
    //            stateMachine.ChangeState(playerMovement.standingState);
    //    }
    //}

    //public override void PhysicsUpdate()
    //{
    //    base.PhysicsUpdate();
        
    //    if (!grounded)
    //    {

    //        if (playerMovement.rb.velocity.y <= 0)
    //            playerMovement.rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    //        else if (playerMovement.rb.velocity.y > 0)
    //            playerMovement.rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;

    //        if (delayTimer >= delay)
    //        {
    //            grounded = Physics.Raycast(playerMovement.playerFeet.transform.position, Vector3.down, 0.1f);
    //            delayTimer = 0.0f;
    //        }

    //    }
    //}
}
