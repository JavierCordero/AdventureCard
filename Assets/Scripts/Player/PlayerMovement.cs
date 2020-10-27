using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Speeds
    [HideInInspector] 
    public float startSpeed;
  
    [HideInInspector]
    public float currentSpeed;

    [Range(0f, 1f)] 
    [SerializeField] 
    public float buildUpSpeed;

    public float rotationSpeed = 1.2f;
    public float playerRotationSpeed = 0.1f;
    public float speedMultiplier = 2.5f;
    public float jumpForce = 10.0f;


    public float rollWalkCooldown = 0.8f;
    public float rollRunCooldown = 1.1f;

    public GameObject playerRepresentation;
    public GameObject playerFeet;

    [HideInInspector]
    public Rigidbody rb;

    private PlayerInputHandler playerInput;

    public Animator playerAnimator;


    //STATES
    [SerializeField]
    public StateMachine movementSM;
    public StandingState standingState;
    public JumpingState jumpingState;
    public RunningState runningState;
    public WalkingState walkingState;
    public RollingState rollingState;
    public AttackState attackState;

    [SerializeField]
    private PlayerAnimationController animationController;
    public PlayerAnimationController GetPlayerAnimationController() => animationController;

    private bool playerCanMove = true;

    void Awake()
    {
        currentSpeed = startSpeed;
    }


    private void Start()
    {
        movementSM = new StateMachine();

        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputHandler>();
        FindObjectOfType<GeneralAnimationManager>().FadeOut();

        //States initialization
        standingState = new StandingState(this, movementSM, animationController);
        //jumpingState = new JumpingState(this, movementSM, animationController);
        runningState = new RunningState(this, movementSM, animationController, playerInput);
        walkingState = new WalkingState(this, movementSM, animationController, playerInput);
        //rollingState = new RollingState(this, movementSM, animationController, playerInput);
        attackState = new AttackState(this, movementSM, animationController);

        movementSM.Initialize(standingState);
    }



    private void Update()
    {
        movementSM.CurrentState.HandleInput();
        movementSM.CurrentState.LogicUpdate();

    }

    void FixedUpdate()
    {
        movementSM.CurrentState.PhysicsUpdate();
    }

    public void ActivateAttack()
    {
        movementSM.CurrentState.AttackPressed();
    }

    public void ActiveJump()
    {
        //movementSM.CurrentState.JumpPressed();
    }
    public void ActiveRun(bool active)
    {
        movementSM.CurrentState.RunPressed(active);
    }
    public void ActiveWalk(bool p)
    {
        movementSM.CurrentState.MovePressed(p);
    }
    public void ActiveRoll()
    {
        //movementSM.CurrentState.RollPressed();
    }
    public void EnablePlayerMovement(bool value)
    {
        playerCanMove = value;
    }

}
