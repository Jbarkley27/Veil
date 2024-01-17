//using TMPro;
//using UnityEngine;

// OLD CODE RELATED TO SHIP MOVEMENT

//public class Movement : MonoBehaviour
//{
//    private InputManager inputManager;

//    [Header("Animation")]
//    public Animator animator;
//    public float dampTime;

//    [Header("Rotation")]
//    public Vector3 ShipRotation;
//    private Rigidbody rb;
//    public Quaternion TargetRotation;
//    public float correctingRotationSpeed;
//    public float innerRotationSpeed = 1;
//    public float middleRotationSpeed = 5;
//    public float outerRotationSpeed = 7.5f;
//    public float rollMult;

//    public float playerZRotInput;


//    [Header("Thrust")]
//    public float thrustMultiplier;

//    [Header("Hovering")]
//    public float hoverMultiplier;

//    [Header("Reticle")]
//    public GameObject camFollow;



//    [Header("Debug")]
//    public TMP_Text debugText;

//    void Start()
//    {
//        inputManager = GetComponent<InputManager>();
//        rb = GetComponent<Rigidbody>();
//    }

//    void Update()
//    {
//        //HandleAnimation();
//    }


//    private void FixedUpdate()
//    {
//        LookAtPoint();
//        HandleThrust();
//        HandleHover();
//    }

//    public void HandleRoll()
//    {
//        if (inputManager.RollingLeft)
//        {
//            playerZRotInput = 1f;
//        }
//        else if (inputManager.RollingRight)
//        {
//            playerZRotInput = -1f;
//        }
//        else
//        {
//            playerZRotInput = 0;
//        }
//    }

//    public float GetRotationSpeed()
//    {
//        if (FreeCursor.InInnerBounds)
//        {
//            return innerRotationSpeed;
//        }

//        if (FreeCursor.InMiddleBounds)
//        {
//            return middleRotationSpeed;
//        }

//        if (FreeCursor.InOuterBounds)
//        {
//            return outerRotationSpeed;
//        }

//        return 0;
//    }

//    public void HandleThrust()
//    {
//        if (inputManager.ThrustInput.sqrMagnitude != 0)
//        {
//            Vector3 thrustVector = new Vector3(-inputManager.ThrustInput.x, 0, -inputManager.ThrustInput.y);
//            rb.AddForce(thrustMultiplier * Time.deltaTime * thrustVector, ForceMode.VelocityChange);
//        }
//    }

//    public void HandleHover()
//    {
//        if (inputManager.HoveringUp)
//        {
//            Vector3 hoverVector = new Vector3(0, hoverMultiplier, 0);
//            rb.AddForce(Time.deltaTime * hoverVector, ForceMode.VelocityChange);
//        }

//        if (inputManager.HoveringDown)
//        {
//            Vector3 hoverVector = new Vector3(0, -hoverMultiplier, 0);
//            rb.AddForce(Time.deltaTime * hoverVector, ForceMode.VelocityChange);
//        }
//    }


//    public void ResetRotation()
//    {
//        Vector3 resetRot = new Vector3(rb.rotation.x, rb.rotation.y, 0f);
//        rb.MoveRotation(Quaternion.Euler(resetRot));
//    }
    
//    public void LookAtPoint()
//    {
//        HandleRoll();
//        var localTarget = transform.InverseTransformPoint(camFollow.transform.position);

//        var angleY = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
//        var angleX = Mathf.Atan2(localTarget.y, localTarget.z) * Mathf.Rad2Deg * -1f;


//        Vector3 eulerAngleVelocity = new Vector3(angleX * GetRotationSpeed(), angleY * GetRotationSpeed(), playerZRotInput * rollMult);
//        debugText.text = $"Angle -- {eulerAngleVelocity}";
//        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
//        //Debug.Log("Delta Roataio -- " + deltaRotation);
//        rb.MoveRotation(rb.rotation * deltaRotation);

//    }

//    public void HandleAnimation()
//    {
//        animator.SetFloat("X", inputManager.RawMovementInput.x, dampTime, Time.deltaTime);
//    }

//}
