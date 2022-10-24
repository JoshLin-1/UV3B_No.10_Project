using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.Events; 

[CreateAssetMenu(menuName = "Player Input")]
public class PlayerController : ScriptableObject, PlayerInputScheme.IPlayerActions, PlayerInputScheme.IMenuActions
{
    
    public event UnityAction<Vector2> onMovement = delegate {};
    public event UnityAction onStopMove = delegate {};

    public event UnityAction onInteract = delegate {};
    public event UnityAction onStopInteract = delegate {};

    public event UnityAction onEscapeMenu = delegate {};
    public event UnityAction onStopEscapeMenu = delegate {};

    public event UnityAction onJump= delegate {};
    public event UnityAction onStopJump = delegate {};

    PlayerInputScheme _inputScheme;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        _inputScheme = new PlayerInputScheme();
        _inputScheme.Player.SetCallbacks(this);
        _inputScheme.Menu.SetCallbacks(this);
    }

    void OnDisable()
    {
        DisableAllInputs();
    }

    public void DisableAllInputs()
    {
        _inputScheme.Player.Disable();
        _inputScheme.Menu.Disable();
    }

    public void DisablePlayerInputs()
    {
        _inputScheme.Player.Disable();
    }

    public void EnableGameplayInput()
    {
        _inputScheme.Player.Enable();
        _inputScheme.Menu.Enable();

        // Cursor.visible = false; 
        // Cursor.lockState = CursorLockMode.Locked; 

    }

   public void OnMovement(InputAction.CallbackContext context)
   {
        if(context.phase == InputActionPhase.Performed)
        {
            if(onMovement != null) //= delegate {}; 這個就不用加了
            {
                onMovement.Invoke(context.ReadValue<Vector2>());
            }
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            onStopMove.Invoke();
        }
   }

   public void OnInteract(InputAction.CallbackContext context)
   {
         if(context.phase == InputActionPhase.Started)
        {
           
            onInteract.Invoke();
            
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            onStopInteract.Invoke();
        }
   }

   public void OnEscapeMenu(InputAction.CallbackContext context)
   {
        if(context.phase == InputActionPhase.Started)
        {
           
            onEscapeMenu.Invoke();
            
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            onStopEscapeMenu.Invoke();
        }
   }

   public void OnJump(InputAction.CallbackContext context)
   {
        if(context.phase == InputActionPhase.Started)
        {
           
            onJump.Invoke();
            
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            onStopJump.Invoke();
        }
   }
}
