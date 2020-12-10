using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    private float currentSpeed;
    [Range(0f, 1f)] [SerializeField] private float buildUpSpeed;

    private Vector2 movementInput;
    private Vector2 newMovementInput;
    private Vector3 forward;

    public Vector2 deadZone = new Vector2(0.02f, 0.02f);

    private Rigidbody rb;

    public PlayerInputHandler playerInput;

    public float rotationSpeed = 1.2f;

    public Animator playerAnimator;
    private Vector3 heading;
    public GameObject playerRepresentation;
    public float playerRotationSpeed = 0.1f;
    public float speedMultiplier = 2.5f;

    public GameObject playerFeet;

    public float jumpCooldown = 1.5f;

    public float GravityMultiplier = 100;

    private bool playerCanMove_ = true;

    [SerializeField]
    private PlayerAnimationController animationController;
    void Awake()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        currentSpeed = startSpeed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputHandler>();
    }

    void FixedUpdate()
    {
        if (playerCanMove_)
        {
            newMovementInput = playerInput.movementInput;

            if (playerInput.movementInput == Vector2.zero)
            {
                SetIdlePlayer();
            }

            else
            {

                float realBuildUpSpeed = 1f - Mathf.Pow(1f - buildUpSpeed, Time.deltaTime * 60);
                movementInput = Vector2.Lerp(movementInput, newMovementInput, realBuildUpSpeed);


                animationController.EnableWalk();

                if (playerInput.run)
                {
                    currentSpeed = startSpeed * speedMultiplier;
                    animationController.EnableRun();
                }

                heading = (Vector3.Normalize(Camera.main.transform.forward) * newMovementInput.y +
                   Vector3.Normalize(Camera.main.transform.right) * newMovementInput.x);

                heading.y = 0.0f;

                transform.forward = transform.forward;//Vector3.Slerp(transform.forward, heading, rotationSpeed * Time.deltaTime);

                rb.velocity = heading * currentSpeed;

                playerRepresentation.transform.rotation = Quaternion.Lerp(playerRepresentation.transform.rotation, Quaternion.LookRotation(heading, Vector3.up), playerRotationSpeed);

                currentSpeed = startSpeed;
            }
        }

        else
        {
            SetIdlePlayer();
        }
    }

    private void Update()
    {
        if(playerInput.attack)
        {
            animationController.EnableAtack(1);
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
}