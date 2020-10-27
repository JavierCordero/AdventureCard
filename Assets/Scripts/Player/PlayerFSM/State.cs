using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State : StateMachineBehaviour
{
    protected PlayerMovement playerMovement;
    protected PlayerAnimationController playerAnimation;
    protected PlayerInputHandler playerInput;

    private Vector2 newMovementInput;
    private Vector2 movementInput;
    private Vector3 heading;
    private Vector3 rotationLookVector;

    protected void GetComponents(GameObject go)
    {
        if(!playerMovement)
             playerMovement = go.GetComponentInParent<PlayerMovement>();
        if (!playerAnimation)
            playerAnimation = go.GetComponentInParent<PlayerAnimationController>();
        if (!playerInput)
            playerInput = go.GetComponentInParent<PlayerInputHandler>();

    }
    protected void Move()
    {
        if (playerMovement.playerCanMove)
        {
            newMovementInput = playerInput.movementInput;

            if (newMovementInput == Vector2.zero)
            {
                playerAnimation.EnableIdle();
            }

            float realBuildUpSpeed = 1f - Mathf.Pow(1f - playerMovement.buildUpSpeed, Time.deltaTime * 60);
            movementInput = Vector2.Lerp(movementInput, newMovementInput, realBuildUpSpeed);

            heading = (Vector3.Normalize(Camera.main.transform.forward) * newMovementInput.y +
                   Vector3.Normalize(Camera.main.transform.right) * newMovementInput.x);


            rotationLookVector.x = heading.x;
            rotationLookVector.z = heading.z;

            playerMovement.playerRepresentation.transform.rotation = Quaternion.Lerp(playerMovement.playerRepresentation.transform.rotation,
                Quaternion.LookRotation(rotationLookVector, Vector3.up), playerMovement.playerRotationSpeed);

            playerMovement.rb.velocity = new Vector3(heading.x * playerMovement.currentSpeed, playerMovement.rb.velocity.y, heading.z * playerMovement.currentSpeed);
        }
    }

}
