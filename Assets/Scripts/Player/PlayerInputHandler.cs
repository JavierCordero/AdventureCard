using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput { get; protected set; }
    public Vector2 aimInput { get; protected set; }

    public bool running { get; protected set; }

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

        playerInputActions.PlayerControls.Move.performed += Move_Performed;
        playerInputActions.PlayerControls.Move.canceled += Move_Cancelled;
        playerInputActions.PlayerControls.Run.performed += Run_Performed;
        playerInputActions.PlayerControls.Run.canceled += Run_Cancelled;
        playerInputActions.PlayerActions.PlayerTargetSelector.performed += Target_Selector_Performed;
        playerInputActions.PlayerActions.PlayerTargetSelector.canceled += Target_Selector_Cancelled;
        playerInputActions.PlayerActions.Roll.performed += Roll_Performed;

        playerInputActions.PlayerActions.Interaction.performed += Interaction_Performed;


        playerInputActions.PlayerActions.Pause.performed += SetPauseMode;

        //playerInputActions.PlayerControls.QuitGame.performed += Exit_Game;     

    }

    void OnDisable()
    {
        playerInputActions.PlayerControls.Move.performed -= Move_Performed;
        playerInputActions.PlayerControls.Move.canceled -= Move_Cancelled;
        playerInputActions.PlayerControls.Run.performed -= Run_Performed;
        playerInputActions.PlayerControls.Run.canceled -= Run_Cancelled;

        playerInputActions.PlayerActions.PlayerTargetSelector.performed -= Target_Selector_Performed;
        playerInputActions.PlayerActions.PlayerTargetSelector.canceled -= Target_Selector_Cancelled;

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
            if(PauseCanvas.activeSelf)
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
    }
    private void Move_Cancelled(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero;
    }

    private void Run_Performed(InputAction.CallbackContext context)
    {
        if (playerMovement)
            playerMovement.running = true;
    }

    private void Run_Cancelled(InputAction.CallbackContext context)
    {
        if (playerMovement)
            playerMovement.running = false;
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {
        if (playerMovement)
            playerMovement.jump();
    }

    private void Dash_Performed(InputAction.CallbackContext context)
    {
        if (playerMovement)
            playerMovement.dash();
    }

    private void Target_Selector_Performed(InputAction.CallbackContext context)
    {
        if (playerTargetSelector_)
            playerTargetSelector_.EnableTargetSelector();
    }

    private void Target_Selector_Cancelled(InputAction.CallbackContext context)
    {
        if (playerTargetSelector_)
            playerTargetSelector_.DisableTargetSelector();
    }

    private void Roll_Performed(InputAction.CallbackContext context)
    {
        if (playerMovement)
            playerMovement.Roll();
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
