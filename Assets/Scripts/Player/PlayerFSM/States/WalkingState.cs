using UnityEngine;

public class WalkingState : State
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetComponents(animator.gameObject);

        playerMovement.currentSpeed = playerMovement.startSpeed;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move();
        
        if(playerInput.run)
        {
            playerAnimation.EnableRun();
            return;
        }
        if (playerInput.attack)
        {
            playerAnimation.EnableAtack(Random.Range(0, 3) + 1);
            return;
        }
        if (playerInput.block)
        {
            playerAnimation.lastMove = "Walk";
            playerAnimation.EnableBlock();
            return;
        }
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
