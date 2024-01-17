using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Windows;
using UnityEngine.UIElements.Experimental;
using FMODUnity;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }
    public PlayerInput input;



   

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found an Input Manager object, destroying new one.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //Focus();
        //ShootPrimary();
        //ShootSecondary();
        Roll();
    }


    #region ThirdPersonController
    //[Header("Movement")]
    //public Vector2 RawMovementInput;

    //[Header("Jump")]
    //public bool JumpPressed;

    //[Header("Shooting")]
    //public bool ShootingPrimary;
    //public bool BlockPrimaryShootingUntilShootButtonIsStopped;

    //public bool ShootingSecondary;
    //public bool BlockSecondaryShootingUntilShootButtonIsStopped;

    //[Header("Dash")]
    //public bool DashPressed;

    //[Header("Focus")]
    //public bool hasPlayedFocusSound = false;
    //public bool FocusPressed;

    // MOVEMENT ======================
    //public void Movement(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        RawMovementInput = context.ReadValue<Vector2>().normalized;
    //    }
    //}




    // JUMP =========================
    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        JumpPressed = true;
    //    }

    //    else if (context.canceled)
    //    {
    //        JumpPressed = false;
    //    }
        
    //}


    // FOCUS ========================

    //public void Focus()
    //{
    //    if (input.actions["Focus"].IsPressed())
    //    {
    //        FocusPressed = true;

    //        if (!hasPlayedFocusSound)
    //        {
    //            RuntimeManager.PlayOneShot(AudioLibrary.ZoomIn, transform.position);
    //            hasPlayedFocusSound = true;
    //        }

    //    }
    //    else if (input.actions["Focus"].WasReleasedThisFrame())
    //    {
    //        FocusPressed = false;
    //        RuntimeManager.PlayOneShot(AudioLibrary.ZoomOut, transform.position);
    //        hasPlayedFocusSound = false;
    //    }
    //}


    //// SHOOT PRIMARY
    //public void ShootPrimary()
    //{
    //    if (input.actions["ShootingPrimary"].IsPressed())
    //    {
    //        ShootingPrimary = true;
    //        ShootingSecondary = false;
    //    }

    //    else if (input.actions["ShootingPrimary"].WasReleasedThisFrame())
    //    {
    //        ShootingPrimary = false;
    //        BlockPrimaryShootingUntilShootButtonIsStopped = false;
    //    }
    //}




    //// SHOOT PRIMARY
    //public void ShootSecondary()
    //{
    //    if (input.actions["ShootingSecondary"].IsPressed())
    //    {
    //        ShootingSecondary = true;
    //        ShootingPrimary = false;
    //    }

    //    else if (input.actions["ShootingSecondary"].WasReleasedThisFrame())
    //    {
    //        ShootingSecondary = false;
    //        BlockSecondaryShootingUntilShootButtonIsStopped = false;
    //    }
    //}



    //// DASH
    //public void Dash(InputAction.CallbackContext context)
    //{
    //    if (!context.performed) return;
    //    DashPressed = true;
    //}

    #endregion

    #region KestralController
    
    [Header("Kestral Movement")]
    public static Vector2 RawKestralMovementInput;

    public void MovementKestral(InputAction.CallbackContext context)
    {
        //Debug.Log(RawKestralMovementInput);
        if (context.performed)
        {
            RawKestralMovementInput = context.ReadValue<Vector2>().normalized;
        }
    }

    [Header("Roll")]
    public static bool RollLeft = false;
    public static bool RollRight = false;

    public void Roll()
    {
        if (input.actions["RollLeft"].IsPressed())
        {
            RollLeft = true;
        }
        else if (input.actions["RollLeft"].WasReleasedThisFrame())
        {
            RollLeft = false;
        }



        if (input.actions["RollRight"].IsPressed())
        {
            RollRight = true;
        }
        else if (input.actions["RollRight"].WasReleasedThisFrame())
        {
            RollRight = false;
        }

    }

    #endregion

    // UTILITIES =====================

    public void SwitchToUIMap()
    {
        Debug.Log("Switching to UI map");
        input.SwitchCurrentActionMap("UI");
    }

    public void SwitchToGameplayMap()
    {
        Debug.Log("Switching to Gameplay Map");
        input.SwitchCurrentActionMap("Gameplay");
    }


    

}
