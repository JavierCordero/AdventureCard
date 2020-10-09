using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 movementInput { get; protected set; }
    public Vector2 aimInput { get; protected set; }

    public bool running { get; protected set; }

    private PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PlayerTargetSelector playerTargetSelector_;
    void Awake()
    {
        InitInput();
    }

	private void InitInput()
    {
        if (playerInputActions == null)
            playerInputActions = new PlayerInputActions();

        playerMovement = GetComponent<PlayerMovement>();

        if (!playerMovement)
            playerMovement = new PlayerMovement();

        if (!playerTargetSelector_)
            playerTargetSelector_ = GetComponent<PlayerTargetSelector>();
    }

    void OnEnable()
    {
        playerInputActions.Enable();

        playerInputActions.PlayerControls.Move.performed += Move_Performed;
        playerInputActions.PlayerControls.Move.canceled += Move_Cancelled;
        playerInputActions.PlayerControls.Run.performed += Run_Performed;
        playerInputActions.PlayerControls.Run.canceled += Run_Cancelled;
        playerInputActions.PlayerControls.Jump.performed += Jump_Performed;
        playerInputActions.PlayerControls.Dash.performed += Dash_Performed;
        playerInputActions.PlayerActions.PlayerTargetSelector.performed += Target_Selector_Performed;
        playerInputActions.PlayerActions.PlayerTargetSelector.canceled += Target_Selector_Cancelled;
        //playerInputActions.PlayerControls.QuitGame.performed += Exit_Game;     

    }

    void OnDisable()
    {
        playerInputActions.PlayerControls.Move.performed -= Move_Performed;
        playerInputActions.PlayerControls.Move.canceled -= Move_Cancelled;
        playerInputActions.PlayerControls.Run.performed -= Run_Performed;
        playerInputActions.PlayerControls.Run.canceled -= Run_Cancelled;
        playerInputActions.PlayerControls.Jump.performed -= Jump_Performed;
        playerInputActions.PlayerControls.Dash.performed -= Dash_Performed;

        playerInputActions.PlayerActions.PlayerTargetSelector.performed -= Target_Selector_Performed;
        playerInputActions.PlayerActions.PlayerTargetSelector.canceled -= Target_Selector_Cancelled;

        //playerInputActions.PlayerControls.QuitGame.performed -= Exit_Game;

        playerInputActions.Disable();
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
        playerMovement.running = true;
    }

    private void Run_Cancelled(InputAction.CallbackContext context)
    {
        playerMovement.running = false;
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {
        playerMovement.jump();
    }

    private void Dash_Performed(InputAction.CallbackContext context)
    {
        playerMovement.dash();
    }

    private void Target_Selector_Performed(InputAction.CallbackContext context)
    {
        playerTargetSelector_.EnableTargetSelector();
    }

    private void Target_Selector_Cancelled(InputAction.CallbackContext context)
    {
        playerTargetSelector_.DisableTargetSelector();
    }

    private void Exit_Game(InputAction.CallbackContext context)
    {
        //GameManager.Instance.QuitGame();
    }

}
