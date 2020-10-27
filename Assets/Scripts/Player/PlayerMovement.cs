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

    [HideInInspector]
    public PlayerInputHandler playerInput;

    public Animator playerAnimator;

    [SerializeField]
    private PlayerAnimationController animationController;
    public PlayerAnimationController GetPlayerAnimationController() => animationController;

    [HideInInspector]
    public bool playerCanMove = true;

    void Awake()
    {
        currentSpeed = startSpeed;
    }


    private void Start()
    {
       rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputHandler>();
        FindObjectOfType<GeneralAnimationManager>().FadeOut();

   }

    public void EnablePlayerMovement(bool value)
    {
        playerCanMove = value;
    }

}
