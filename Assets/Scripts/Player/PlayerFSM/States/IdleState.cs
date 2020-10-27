using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : State
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetComponents(animator.gameObject);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (playerInput.movementInput != Vector2.zero)
        {
            playerAnimation.EnableWalk();
            return;
        }
        if (playerInput.attack)
        {
            playerAnimation.EnableAtack(Random.Range(0, 3) + 1);
            return;
        }
        if (playerInput.block)
        {
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
