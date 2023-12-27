using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class InputManager : MonoBehaviour
{
    public Vector2 RawMovementInput;
    //public Vector2 RawThrustMovement;
    public Vector3 ShipRotation;
    public float rotationSpeed;
    private Rigidbody rb;
    public Quaternion TargetRotation;
    public Animator animator;
    public float dampTime;
    public float correctingRotationSpeed;
    
    //public Transform ship;

    [Header("Dash")]
    public float DashForce;
    private PlayerInput input;

    [Header("Debug")]
    public float debugRayLength;
    public TMP_Text velocityText;


    // Start is called before the first frame update
    void Start()
    {
        RawMovementInput = new Vector2(0, 0);
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }


    //public float zDampener;
    private void Update()
    {
        HandleRotation();

        // This fights the Z rotation which can make things feel dizzy and feel like the camera is out of sync
        ZRotationCorrection();

        DebugStuff();

        HandleAnimation();
    }

    public void HandleRotation()
    {
        ShipRotation = new Vector3(-RawMovementInput.y, RawMovementInput.x, 0);
        TargetRotation = Quaternion.Euler(ShipRotation);

        if (RawMovementInput.sqrMagnitude != 0) transform.Rotate(rotationSpeed * Time.deltaTime * ShipRotation, Space.Self);
    }


    public void ZRotationCorrection()
    {
        Vector3 wantedRotation = new(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(wantedRotation), Time.deltaTime * correctingRotationSpeed);
    }



    public void HandleAnimation()
    {
        animator.SetFloat("X", RawMovementInput.x, dampTime, Time.deltaTime);
    }




    public void DebugStuff()
    {
        //Debug.DrawRay(transform.position, transform.right * debugRayLength, Color.red);
        //Debug.DrawRay(transform.position, -transform.right * debugRayLength, Color.red);
        velocityText.text = $"Velocity: {rb.velocity}";
    }





    public float MaxXVelocity;
    public void FixedUpdate()
    {
        if (rb.velocity.x > MaxXVelocity || rb.velocity.x < -MaxXVelocity)
        {
            if (Mathf.Sign(rb.velocity.x) < 0)
            {
                rb.velocity = new Vector3(-MaxXVelocity, rb.velocity.y, rb.velocity.z);
            } else
            {
                rb.velocity = new Vector3(MaxXVelocity, rb.velocity.y, rb.velocity.z);
            }
        }

        Boost();
    }

    public float boostForce;
    public void Boost()
    {
        if (input.actions["Boost"].IsPressed())
        {
            rb.AddForce(transform.forward * boostForce * Time.deltaTime);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RawMovementInput = context.ReadValue<Vector2>().normalized;
        }
    }

    //public void Thrust(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        RawThrustMovement = context.ReadValue<Vector2>().normalized;


    //    }
    //}

    //public void DashLeft(InputAction.CallbackContext context)
    //{
    //    if(context.performed)
    //    {
    //        rb.velocity = new Vector3(-DashForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    //        //rb.AddForce(-transform.right * DashForce * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}

    //public void DashRight(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        rb.velocity = new Vector3(DashForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    //        //rb.AddForce(transform.right * DashForce * Time.deltaTime, ForceMode.Impulse);
    //    }
    //}

}
