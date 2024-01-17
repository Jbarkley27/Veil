//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Cinemachine;
//using FMODUnity;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.XR;

//public class CharacterMovement : MonoBehaviour
//{

//    #region General
//    [Header("General")]
//    CharacterController cc;
//    public CinemachineFreeLook cinCam;
//    #endregion


//    #region Movement
//    [Header("Movement")]
//    private Vector3 cameraRelativeMovement = new Vector3(0, 0, 0);
//    public float movementSpeed;
//    public float rotationSpeed;
//    [SerializeField] private float smoothTime = 0.05f;
//    private float _currentVelocity;
//    public float gravity = -9.81f;
//    public float gravMult = 3f;
//    #endregion


//    #region Jump
//    [Header("Jump")]
//    public float velocity;
//    public float JumpPower;
//    #endregion


//    #region Dash
//    [Header("Dash")]
//    public float dashTime;
//    public float dashLength;
//    public float dashSpeed;
//    public bool dashing = false;
//    public float dashCooldown;
//    #endregion


//    #region Look/Rotate Camera
//    [Header("Camera Sensitivity")]

//    [Range(0f, 5f)]
//    [SerializeField] float sensitivityX;

//    [Range(0f, 5f)]
//    [SerializeField] float sensitivityY;

//    // Helps to get a good baseline for each axis
//    // X axis uses a much larger value to equalize the two
//    private int baseXSensitivity = 100;
//    private int baseYSensitivity = 1;
//    #endregion


//    #region Focus
//    [Header("Focus")]
//    public float zoomFOV = 30f;
//    public float defaultFOV = 50f;
//    public float currentFOV = 50f;
//    public bool shouldZoom = false;
//    public float fovSpeed = 2f;
//    public float smoothTimeRefocusAfterZoomOut = 10f;

//    [Range(.1f, 1f)]
//    public float focusAimReducerX;

//    [Range(.1f, 1f)]
//    public float focusAimReducerY;
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        cc = GetComponent<CharacterController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        HandleCameraRelativeMovement();
//        HandleRotation();
//        ApplyGravity();
//        HandleMovement();
//        JumpListener();
//        FocusListener();
//        DashListener();
//    }

    


//    #region Focus

//    public void FocusListener()
//    {
//        shouldZoom = InputManager.instance.FocusPressed;
//        currentFOV = shouldZoom ? zoomFOV : defaultFOV;
//        cinCam.m_Lens.FieldOfView = Mathf.Lerp(cinCam.m_Lens.FieldOfView, currentFOV, Time.deltaTime * fovSpeed);

//        if (shouldZoom)
//        {
//            cinCam.m_XAxis.m_MaxSpeed = baseXSensitivity * sensitivityX * focusAimReducerX;
//            cinCam.m_YAxis.m_MaxSpeed = baseYSensitivity * sensitivityY * focusAimReducerY;
//        }
//        else
//        {
//            cinCam.m_XAxis.m_MaxSpeed = baseXSensitivity * sensitivityX;
//            cinCam.m_YAxis.m_MaxSpeed = baseYSensitivity * sensitivityY;
//        }
//    }
//    #endregion



//    #region Movement
//    public void ApplyGravity()
//    {
//        if(cc.isGrounded && velocity < 0)
//        {
//            velocity = -1f;
//        }
//        else
//        {
//            velocity += gravity * Time.deltaTime * gravMult;
//        }
//    }

//    public void HandleMovement()
//    {
//        cameraRelativeMovement.y = velocity;
//        cc.Move(movementSpeed * Time.deltaTime * cameraRelativeMovement);
//    }

//    void HandleCameraRelativeMovement()
//    {
//        var input = InputManager.instance.RawMovementInput;
//        Vector3 forward = Camera.main.transform.forward;
//        Vector3 right = Camera.main.transform.right;

//        forward.y = 0;
//        right.y = 0;
//        forward = forward.normalized;
//        right = right.normalized;

//        Vector3 forwardRelativeInput = input.y * forward;
//        Vector3 rightRelativeInput = input.x * right;

//        cameraRelativeMovement = forwardRelativeInput + rightRelativeInput;
//    }

//    void HandleRotation()
//    {
//        if (InputManager.instance.RawMovementInput.sqrMagnitude == 0) return;

//        var targetAngle = Mathf.Atan2(cameraRelativeMovement.x, cameraRelativeMovement.z) * Mathf.Rad2Deg;
//        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
//        transform.rotation = Quaternion.Euler(0, angle, 0);
//    }


//    #endregion




//    #region Jump
//    public void JumpListener()
//    {
//        if (!cc.isGrounded) return;
//        if (!InputManager.instance.JumpPressed) return;

//        velocity = JumpPower;

//        InputManager.instance.JumpPressed = false;
//    }

//    #endregion




//    #region Dash

//    public void DashListener()
//    {
//        if (!InputManager.instance.DashPressed) return;
//        if (dashing) return;

//        StartCoroutine(DashCorutine());
//    }

//    private IEnumerator DashCorutine()
//    {
//        dashing = true;
//        float startTime = Time.time;
//        while (startTime + dashTime > Time.time)
//        {
//            Vector3 moveDirection = transform.forward * dashLength;
//            cc.Move(moveDirection * Time.deltaTime * dashSpeed);
//            yield return null;
//        }


//        yield return new WaitForSeconds(dashCooldown);

//        InputManager.instance.DashPressed = false;
//        dashing = false;
//    }


//    #endregion


//}
