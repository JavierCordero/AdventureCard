using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput { get; protected set; }
    public Vector2 aimInput { get; protected set; }

    //public bool running { get; protected set; }

    public bool run = false;
    public bool movement = false;
    public bool attack = false;
    public bool block = false;

    public bool _shooting = false;


    public GameObject PauseCanvas;

    private PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction_;

    private GameManager gm;

    void Awake()
    {
        InitInput();
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void InitInput()
    {
        if (playerInputActions == null)
            playerInputActions = new PlayerInputActions();

        playerMovement = GetComponent<PlayerMovement>();

        playerInteraction_ = GetComponent<PlayerInteraction>();

    }

    void OnEnable()
    {
        playerInputActions.Enable();

        //Player controls
        playerInputActions.PlayerControls.Move.performed += Move_Performed;
        playerInputActions.PlayerControls.Move.canceled += Move_Cancelled;
        playerInputActions.PlayerControls.Run.started += Run_Performed;
        playerInputActions.PlayerControls.Run.canceled += Run_Cancelled;
        playerInputActions.PlayerControls.Block.performed += Block_Performed;

        //Player actions
        playerInputActions.PlayerActions.Attack.performed += Attack_Performed;
        playerInputActions.PlayerActions.Attack.canceled += Attack_Cancelled;
        playerInputActions.PlayerActions.Shoot.performed += Shoot_Performed;
        playerInputActions.PlayerActions.Shoot.canceled += Shoot_Cancelled;


        playerInputActions.PlayerActions.Interaction.performed += Interaction_Performed;


        playerInputActions.PlayerActions.Pause.performed += SetPauseMode;

        //playerInputActions.PlayerControls.QuitGame.performed += Exit_Game;     

    }

    void OnDisable()
    {
        playerInputActions.PlayerControls.Move.performed -= Move_Performed;
        playerInputActions.PlayerControls.Move.canceled -= Move_Cancelled;
        playerInputActions.PlayerControls.Run.started -= Run_Performed;
        playerInputActions.PlayerControls.Run.canceled -= Run_Cancelled;
        playerInputActions.PlayerControls.Block.performed -= Block_Performed;


        playerInputActions.PlayerActions.Attack.performed -= Attack_Performed;
        playerInputActions.PlayerActions.Attack.canceled -= Attack_Cancelled;
        playerInputActions.PlayerActions.Shoot.performed -= Shoot_Performed;
        playerInputActions.PlayerActions.Shoot.canceled -= Shoot_Cancelled;

        playerInputActions.PlayerActions.Interaction.performed -= Interaction_Performed;


        playerInputActions.PlayerActions.Pause.performed -= SetPauseMode;

        //playerInputActions.PlayerControls.QuitGame.performed -= Exit_Game;

        playerInputActions.Disable();
    }

    private void SetPauseMode(InputAction.CallbackContext context)
    {
        if (PauseCanvas)
        {
            PauseCanvas.SetActive(!PauseCanvas.activeSelf);
            if (PauseCanvas.activeSelf)
            {
                Time.timeScale = 0;
                playerMovement.DisablePlayerMovement();
            }

            else
            {
                Time.timeScale = 1;
                playerMovement.EnablePlayerMovement();
            }

        }
    }

    private void Move_Performed(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = true;
       // playerMovement.ActiveWalk(true);
    } 
    private void Block_Performed(InputAction.CallbackContext context)
    {
        if(gm.ShieldEnabled)
            block = true;
    }
    private void Move_Cancelled(InputAction.CallbackContext context)
    {

        movementInput = Vector2.zero;
        movement = false;
    }

    private void Run_Performed(InputAction.CallbackContext context)
    {
        run = true;
    }

    private void Run_Cancelled(InputAction.CallbackContext context)
    {
        run = false;
    }

    private void Attack_Performed(InputAction.CallbackContext context)
    {
        attack = true;
    }

    private void Attack_Cancelled(InputAction.CallbackContext context)
    {
        attack = false;
    }

    private void Shoot_Performed(InputAction.CallbackContext context)
    {
        _shooting = true;
    }

    private void Shoot_Cancelled(InputAction.CallbackContext context)
    {
        _shooting = false;
    }


    private void Interaction_Performed(InputAction.CallbackContext context)
    {
        if (playerInteraction_)
            playerInteraction_.actionPerformed = true;
    }
    private void Exit_Game(InputAction.CallbackContext context)
    {
        //GameManager.Instance.QuitGame();
    }

}
