using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public float jumpForce = 10.0f;



    public GameObject playerFeet;

    public float jumpCooldown = 1.5f;
    private float currentJumpCooldown = 0;


    private bool dashAction = false, canDash = true;
    public float dashCooldown = 3, dashForce = 2;
    private float currentDashCooldown = 0;

    public float GravityMultiplier = 100;

    private bool playerCanMove_ = true;

    private bool playerRolling_ = false;

    private Vector2 playerRollDirection;

    public bool CanRoll = true;


    //Jump variables
    private bool jumpPressed = false;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;
    private bool grounded = true;
    public LayerMask groundLayer;
    private CapsuleCollider capsuleCollider;
    private bool jumping = false;

    [SerializeField]
    private float rollCooldown = 2;

    [SerializeField]
    private PlayerAnimationController animationController;
    void Awake()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;



        currentSpeed = startSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputHandler>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }



    private void Update()
    {

        grounded = Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y - 0.1f,
            capsuleCollider.bounds.center.z), 0.18f, groundLayer);
        Debug.Log(grounded);

    }


    void FixedUpdate()
    {
        if (playerCanMove_)
        {
            //---Jump Control
            if (jumpPressed)
            {
               
                if (grounded)
                {
                    
                    rb.velocity += new Vector3(0, Vector3.up.y * jumpForce, 0);
                    jumping = true;
                    //Prepare jump anim
                    //TODO:

                }
                jumpPressed = false;

            }


            if (!grounded)
            {
                if (rb.velocity.y < 0)
                    rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                else if (rb.velocity.y > 0 && !jumpPressed)
                    rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;

                //In air animation
                
            }
            
            
            //Check for input values
            newMovementInput = playerInput.movementInput;

            //If there is no movement and player is touching the ground set IDLE
            if (!jumping && newMovementInput == Vector2.zero)
                SetIdlePlayer();

            //If there is movement do some cool movements :_D
            else
            {
                if (grounded)
                {
                    if (running)
                    {
                    currentSpeed = startSpeed * speedMultiplier;
                    animationController.EnableRun();
                    }
                    else if (dashAction)
                    {
                        rb.velocity *= dashForce;
                        dashAction = false;
                    }
                    else if (playerRolling_)
                    {
                        newMovementInput = playerRollDirection;
                        currentSpeed = startSpeed * speedMultiplier;
                    }
                    //Else im walking 
                    else 
                    {
                        currentSpeed = startSpeed;
                        animationController.EnableWalk();

                    }
                }

                //---- Input movement control
                float realBuildUpSpeed = 1f - Mathf.Pow(1f - buildUpSpeed, Time.deltaTime * 60);
                movementInput = Vector2.Lerp(movementInput, newMovementInput, realBuildUpSpeed);

                heading = (Vector3.Normalize(Camera.main.transform.forward) * newMovementInput.y +
                      Vector3.Normalize(Camera.main.transform.right) * newMovementInput.x);

                //---- Input movement control

                //Set final speed
                rb.velocity = new Vector3(heading.x * currentSpeed, rb.velocity.y, heading.z * currentSpeed);
                //playerRepresentation.transform.rotation = Quaternion.Lerp(playerRepresentation.transform.rotation, Quaternion.LookRotation(heading, Vector3.up), playerRotationSpeed);

            }

            //Cooldown timers
            if (currentDashCooldown >= 0)
                currentDashCooldown--;
            else canDash = true;

            if (grounded && rb.velocity.y == 0)
                jumping = false;


        } //---- If Player movement END

        //If not player movement
        else
        {
            SetIdlePlayer();
        }


    }

    private void SetIdlePlayer()
    {
        rb.velocity = Vector3.zero;
        animationController.EnableIdle();
    }

    public void DisablePlayerMovement()
    {
        playerCanMove_ = false;
    }

    public void EnablePlayerMovement()
    {
        playerCanMove_ = true;
    }

    public void Roll()
    {
        if (CanRoll && !playerRolling_ && running)
        {
            playerRollDirection = playerInput.movementInput;
            PlayerManager.Instance.PlayerInvencible(true);
            playerRolling_ = true;
            animationController.Roll();
            Invoke("StopRolling", rollCooldown);
        }
    }

    public void StopRolling()
    {
        PlayerManager.Instance.PlayerInvencible(false);
        playerRolling_ = false;
    }

    public void jump()
    {
        jumpPressed = true;
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
