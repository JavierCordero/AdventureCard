using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    protected Vector2 movementInput;
    protected PlayerInputHandler playerInput;
    private Vector3 rotationLookVector;
    private Vector3 heading;

    public MovingState(PlayerMovement p_playerMovement, StateMachine p_stateMachine,
        PlayerAnimationController p_playerAnimation, PlayerInputHandler p_playerInput)
        : base(p_playerMovement, p_stateMachine, p_playerAnimation)
    {
        playerInput = p_playerInput;
    }

    public override void Enter()
    {
        base.Enter();

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

        Vector2 newMovementInput = playerInput.movementInput;

        if (newMovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(playerMovement.standingState);
            return;
        }

        float realBuildUpSpeed = 1f - Mathf.Pow(1f - playerMovement.buildUpSpeed, Time.deltaTime * 60);
        movementInput = Vector2.Lerp(movementInput, newMovementInput, realBuildUpSpeed);

        heading = (Vector3.Normalize(Camera.main.transform.forward) * newMovementInput.y +
               Vector3.Normalize(Camera.main.transform.right) * newMovementInput.x);


        rotationLookVector.x = heading.x;
        rotationLookVector.z = heading.z;

        playerMovement.playerRepresentation.transform.rotation = Quaternion.Lerp(playerMovement.playerRepresentation.transform.rotation,
            Quaternion.LookRotation(rotationLookVector, Vector3.up), playerMovement.playerRotationSpeed);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerMovement.rb.velocity = new Vector3(heading.x * playerMovement.currentSpeed, playerMovement.rb.velocity.y, heading.z * playerMovement.currentSpeed);

        grounded = Physics.Raycast(playerMovement.playerFeet.transform.position, Vector3.down, 0.1f);

        if (!grounded)
        {

            playerMovement.rb.velocity +=  Physics.gravity * Time.fixedDeltaTime;
           
           


        }

    }
}
