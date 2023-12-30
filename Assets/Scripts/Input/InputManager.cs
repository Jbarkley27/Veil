using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class InputManager : MonoBehaviour
{
    public Vector2 RawMovementInput;
    public Vector2 ThrustInput;
    public bool HoveringUp;
    public bool HoveringDown;
    private PlayerInput input;
    public bool RollingLeft;
    public bool RollingRight;

    [Header("Debug")]
    public float debugRayLength;


    // Start is called before the first frame update
    void Start()
    {
        RawMovementInput = new Vector2(0, 0);
        input = GetComponent<PlayerInput>();
        RollingRight = false;
        RollingLeft = false;
    }


    private void Update()
    {

    }



    //public float MaxXVelocity;
    public void FixedUpdate()
    {
        //if (rb.velocity.x > MaxXVelocity || rb.velocity.x < -MaxXVelocity)
        //{
        //    if (Mathf.Sign(rb.velocity.x) < 0)
        //    {
        //        rb.velocity = new Vector3(-MaxXVelocity, rb.velocity.y, rb.velocity.z);
        //    } else
        //    {
        //        rb.velocity = new Vector3(MaxXVelocity, rb.velocity.y, rb.velocity.z);
        //    }
        //}

        //Boost();
    }

    //public float boostForce;
    //public void Boost()
    //{
    //    if (input.actions["Boost"].IsPressed())
    //    {
    //        rb.AddForce(transform.forward * boostForce * Time.deltaTime);
    //    }
    //}

    public void Thrust(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ThrustInput = context.ReadValue<Vector2>();
        }
    }

    public void HoverUp(InputAction.CallbackContext context)
    {
        if (input.actions["Hover Up"].IsPressed())
        {
            HoveringUp = true;
        }

        else if (input.actions["Hover Up"].WasReleasedThisFrame())
        {
            HoveringUp = false;
        }
    }

    public void HoverDown(InputAction.CallbackContext context)
    {
        if (input.actions["Hover Down"].IsPressed())
        {
            HoveringDown = true;
        }

        else if (input.actions["Hover Down"].WasReleasedThisFrame())
        {
            HoveringDown = false;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RawMovementInput = context.ReadValue<Vector2>().normalized;
        }
    }

    public void RollLeft(InputAction.CallbackContext context)
    {
        if (input.actions["Roll Left"].IsPressed())
        {
            RollingLeft = true;
        }

        else if (input.actions["Roll Left"].WasReleasedThisFrame())
        {
            RollingLeft = false;   
        }
    }

    public void RollRight(InputAction.CallbackContext context)
    {
        if (input.actions["Roll Right"].IsPressed())
        {
            RollingRight = true;
        }

        else if (input.actions["Roll Right"].WasReleasedThisFrame())
        {
            RollingRight = false;
        }
    }

}
