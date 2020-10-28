using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : State
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetComponents(animator.gameObject);

        playerMovement.currentSpeed = playerMovement.startSpeed * playerMovement.speedMultiplier;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move();

        if (!playerInput.run)
        {
            playerAnimation.EnableWalk();
            return;
        }
        if (playerInput.attack)
        {
            playerInput.attack = false;
            playerAnimation.EnableAtack(Random.Range(0, 3) + 1);
            return;
        }
        if (playerInput.block)
        {
            playerInput.block = false;
            playerAnimation.lastMove = "Run";
            playerAnimation.EnableBlock();

            return;
        }

    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
