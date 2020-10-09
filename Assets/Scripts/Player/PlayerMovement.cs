using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    private float currentSpeed;
    [Range(0f, 1f)] [SerializeField] private float buildUpSpeed;

    private float minInput;
    private Vector2 movementInput;
    private Vector2 newMovementInput;
    private Vector3 forward;
    private Vector3 right;

    public Vector2 deadZone = new Vector2(0.02f, 0.02f);

    [HideInInspector]
    public bool running = false;

    private Rigidbody rb;

    private PlayerInputHandler playerInput;

    public float rotationSpeed = 1.2f;

    public Animator playerAnimator;
    private Vector3 heading;
    public GameObject playerRepresentation;
    public float playerRotationSpeed = 0.1f;
    public float speedMultiplier = 2.5f;

    public float jumpForce = 4;

    private bool jumping = false;

    public GameObject playerFeet;

    public float jumpCooldown = 1.5f;
    private float currentJumpCooldown = 0;
    private bool canJump = true;

    private bool dashAction = false, canDash = true;
    public float dashCooldown = 3, dashForce = 2;
    private float currentDashCooldown = 0;

    public float GravityMultiplier = 100;

    private bool playerCanMove_ = true;

    void Awake()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputHandler>();

        currentSpeed = startSpeed;
    }

    private void Update()
    {
        //if (jumping)
        //{
        RaycastHit hit;

        Physics.Raycast(new Ray(playerFeet.transform.position, -Vector3.up), out hit, jumpForce / 10);
        if (hit.collider)
            jumping = false;
        else jumping = true;
        //}

        //if (!canJump)
        //{
        //    currentJumpCooldown += Time.deltaTime;
        //    if (currentJumpCooldown >= jumpCooldown)
        //    {
        //        canJump = true;
        //        currentJumpCooldown = 0;
        //    }
        //}
    }


    void FixedUpdate()
    {
        if (playerCanMove_)
        {

            newMovementInput = playerInput.movementInput;

            if (newMovementInput != Vector2.zero)
            {

                float realBuildUpSpeed = 1f - Mathf.Pow(1f - buildUpSpeed, Time.deltaTime * 60);
                movementInput = Vector2.Lerp(movementInput, newMovementInput, realBuildUpSpeed);

                if (!jumping)
                {

                    playerAnimator.SetBool("Run", false);
                    playerAnimator.SetBool("Walk", true);
                    playerAnimator.SetBool("Idle", false);

                    if (running)
                    {
                        currentSpeed = startSpeed * speedMultiplier;
                        playerAnimator.SetBool("Walk", false);
                        playerAnimator.SetBool("Run", true);

                    }
                }
                heading = (Vector3.Normalize(Camera.main.transform.forward) * newMovementInput.y +
                   Vector3.Normalize(Camera.main.transform.right) * newMovementInput.x);

                heading.y = 0.0f;

                transform.forward = transform.forward;//Vector3.Slerp(transform.forward, heading, rotationSpeed * Time.deltaTime);

                rb.velocity = heading * currentSpeed;

                if (dashAction)
                {
                    rb.velocity *= dashForce;
                    dashAction = false;
                }

                if (currentDashCooldown >= 0)
                    currentDashCooldown--;
                else canDash = true;

                playerRepresentation.transform.rotation = Quaternion.Lerp(playerRepresentation.transform.rotation, Quaternion.LookRotation(heading, Vector3.up), playerRotationSpeed);

                currentSpeed = startSpeed;
            }

            else
            {
                rb.velocity = Vector3.zero;

                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Idle", true);
                playerAnimator.SetBool("Run", false);
            }

            if (jumping)
                rb.velocity += Physics.gravity * GravityMultiplier * Time.deltaTime;
        }
    }

    public void DisablePlayerMovement()
    {
        playerCanMove_ = false;
    }

    public void EnablePlayerMovement()
    {
        playerCanMove_ = true;
    }

    public void jump()
    {
        //if (!jumping && canJump)
        //{
        //    canJump = false;
        //    jumping = true;
        //    rb.velocity += Vector3.up * jumpForce;
        //}
    }

    public void dash()
    {
        //if (canDash)
        //{
        //    dashAction = true;
        //    currentDashCooldown = dashCooldown;
        //}
    }
}
