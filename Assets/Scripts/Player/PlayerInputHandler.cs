using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput { get; protected set; }
    public Vector2 aimInput { get; protected set; }

    //public bool running { get; protected set; }

    public bool jump = false;
    public bool run = false;
    public bool movement = false;
    public bool roll = false;
    public bool attack = false;
    public bool block = false;


    public GameObject PauseCanvas;

    private PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PlayerTargetSelector playerTargetSelector_;
    private PlayerInteraction playerInteraction_;
    void Awake()
    {
        InitInput();
    }

    private void InitInput()
    {
        if (playerInputActions == null)
            playerInputActions = new PlayerInputActions();

        playerMovement = GetComponent<PlayerMovement>();
        playerTargetSelector_ = GetComponent<PlayerTargetSelector>();

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
        playerInputActions.PlayerControls.Jump.performed += Jump_Performed;
        playerInputActions.PlayerControls.Block.performed += Block_Performed;

        //Player actions
        playerInputActions.PlayerActions.Attack.performed += Attack_Performed;
        playerInputActions.PlayerActions.Attack.canceled += Attack_Cancelled;
        playerInputActions.PlayerActions.Roll.performed += Roll_Performed;


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
        playerInputActions.PlayerControls.Jump.performed -= Jump_Performed;
        playerInputActions.PlayerControls.Block.performed -= Block_Performed;


        playerInputActions.PlayerActions.Attack.performed -= Attack_Performed;
        playerInputActions.PlayerActions.Attack.canceled -= Attack_Cancelled;

        playerInputActions.PlayerActions.Interaction.performed -= Interaction_Performed;

        playerInputActions.PlayerActions.Roll.performed -= Roll_Performed;

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
                playerMovement.EnablePlayerMovement(false);
            }

            else
            {
                Time.timeScale = 1;
                playerMovement.EnablePlayerMovement(true);
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
        block = true;
    }
    private void Move_Cancelled(InputAction.CallbackContext context)
    {

        movementInput = Vector2.zero;
        movement = false;
      //  playerMovement.ActiveWalk(false);
    }

    private void Run_Performed(InputAction.CallbackContext context)
    {
        run = true;
        //if (playerMovement)
        //    playerMovement.ActiveRun(true);
    }

    private void Run_Cancelled(InputAction.CallbackContext context)
    {
        run = false;
        //if (playerMovement)
        //    playerMovement.ActiveRun(false);
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {
        //if (playerMovement)
        //    playerMovement.ActiveJump();
    }

    private void Dash_Performed(InputAction.CallbackContext context)
    {
        //if (playerMovement)
        //    playerMovement.dash();
    }

    private void Attack_Performed(InputAction.CallbackContext context)
    {
        attack = true;
        //if (playerMovement)
        //    playerMovement.ActivateAttack(true);
    }

    private void Attack_Cancelled(InputAction.CallbackContext context)
    {
        //attack = false;
        //if (playerTargetSelector_)
        //    playerTargetSelector_.DisableTargetSelector();
    }

    private void Roll_Performed(InputAction.CallbackContext context)
    {
        //if (playerMovement)
        //    playerMovement.ActiveRoll();
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
