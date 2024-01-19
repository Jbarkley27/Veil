using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KestralInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PlaceFrontFollowObject();
        HandleAnimation();
        HandleUI();
        HandleRoll();
    }

    private void FixedUpdate()
    {
        LookAtPoint();
        //HandleThrust();
        //HandleHover();
        //HandleBoost();
    }


    [Header("Look At Rotation")]
    public float deadZoneRotationSpeed = .2f;
    public float innerRotationSpeed = 1;
    public float middleRotationSpeed = 5;
    public float outerRotationSpeed = 7.5f;


    public GameObject camFollowObject;
    public float rollMult;
    public float playerZRotInput;
    public Image rotateImage;

    public Rigidbody rb;
    public float autoAlignSpeed;

    public void LookAtPoint()
    {
        // Get Look At Target
        var localTarget = transform.InverseTransformPoint(camFollowObject.transform.position);
        
        var angleY = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        var angleX = Mathf.Atan2(localTarget.y, localTarget.z) * Mathf.Rad2Deg * -1f;


        // Calculate Z Axis Value - figure out which way were tilting
        float angleZNull;
        if (InputManager.AutoAlign)
        {
            
            if (rb.rotation.eulerAngles.z >= 0 && rb.rotation.eulerAngles.z < 180)
            {
                // Tilting Left
                angleZNull = -1f;
                Debug.Log("Tilting Left 1");
            }
            else if (rb.rotation.eulerAngles.z >= 180 && rb.rotation.eulerAngles.z < 360)
            {
                // Tilting Right
                angleZNull = 1f;
                Debug.Log("Tilting Right -1");
            }
            else
            {
                angleZNull = 0;
            }


            angleZNull *= autoAlignSpeed;
            

        } else
        {
            angleZNull = rollMult * playerZRotInput;
            
        }
        
        



        // Begin Rotation
        Vector3 eulerAngleVelocity = new Vector3(angleX * GetRotationSpeed(), angleY * GetRotationSpeed(), angleZNull);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public GameObject autoAlignUI;
    public void TurnAutoAlignUI(bool shouldTurnOn)
    {
        autoAlignUI.SetActive(shouldTurnOn);
    }



    public void HandleRoll()
    {
        if (InputManager.RollLeft)
        {
            playerZRotInput = 1f;
        }
        else if (InputManager.RollRight)
        {
            playerZRotInput = -1f;
        }
        else
        {
            playerZRotInput = 0;
        }
    }

    
    public float GetRotationSpeed()
    {
        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.DEADZONE))
        {
            return deadZoneRotationSpeed;
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.INNER))
        {
            return innerRotationSpeed;
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.MIDDLE))
        {
            return middleRotationSpeed;
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.OUTER))
        {
            return outerRotationSpeed;
        }

        return 0;
    }

    public float xSpeedMultiplier;
    public float GetXRotationSpeed()
    {
        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.DEADZONE))
        {
            return xSpeedMultiplier * deadZoneRotationSpeed * (FreeCursor.IsLeftSideScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.INNER))
        {
            return xSpeedMultiplier * innerRotationSpeed * (FreeCursor.IsLeftSideScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.MIDDLE))
        {
            return xSpeedMultiplier * middleRotationSpeed * (FreeCursor.IsLeftSideScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.OUTER))
        {
            return xSpeedMultiplier * outerRotationSpeed * (FreeCursor.IsLeftSideScreen() ? -1 : 1);
        }

        return 0;
    }

    public float ySpeedMultiplier;
    public float GetYRotationSpeed()
    {
        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.DEADZONE))
        {
            return ySpeedMultiplier * deadZoneRotationSpeed * (FreeCursor.IsBottomOfScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.INNER))
        {
            return ySpeedMultiplier * innerRotationSpeed * (FreeCursor.IsBottomOfScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.MIDDLE))
        {
            return ySpeedMultiplier * middleRotationSpeed * (FreeCursor.IsBottomOfScreen() ? -1 : 1);
        }

        if (FreeCursorCollision.IsInBounds(FreeCursorCollision.Bounds.OUTER))
        {
            return ySpeedMultiplier * outerRotationSpeed * (FreeCursor.IsBottomOfScreen() ? -1 : 1);
        }

        return 0;
    }

    public float frontOffset;
    public float downOffset;
    public GameObject frontFollowObject;

    public void PlaceFrontFollowObject()
    {
        frontFollowObject.transform.position = rb.transform.position +
            rb.transform.forward * frontOffset + rb.transform.up * downOffset;

    }

    [Header("Thrust")]
    public float thrustMultiplier;
    public void HandleThrust()
    {
        if (InputManager.ThrustInput.sqrMagnitude != 0)
        {
            Vector3 thrustVector = new Vector3(InputManager.ThrustInput.x, 0, InputManager.ThrustInput.y);
            rb.AddForce(thrustMultiplier * Time.deltaTime * thrustVector, ForceMode.VelocityChange);
        }
    }

    [Header("Hover")]
    public float hoverMultiplier;

    public void HandleHover()
    {
        if (InputManager.HoverUp)
        {
            Vector3 hoverVector = new Vector3(0, hoverMultiplier, 0);
            rb.AddForce(Time.deltaTime * hoverVector, ForceMode.VelocityChange);
        }

        if (InputManager.HoverDown)
        {
            Vector3 hoverVector = new Vector3(0, -hoverMultiplier, 0);
            rb.AddForce(Time.deltaTime * hoverVector, ForceMode.VelocityChange);
        }
    }


    [Header("Boost")]
    public float ForceMultiplier;
    public void HandleBoost()
    {
        if (!InputManager.Boosting) return;

        rb.AddRelativeForce(Vector3.forward * ForceMultiplier);
    }


    [Header("Animation")]
    public Animator animator;
    public float dampTime;
    public float animationValue;

    public void HandleAnimation()
    {
        animationValue = InputManager.TouchedControls ? FreeCursor.GetAnimationSpeed() : 0;
        
        // make it negative/positive
        animationValue *= !FreeCursor.IsLeftSideScreen() ? -1 : 1;

        animator.SetFloat("X", animationValue, dampTime, Time.deltaTime);

        //Debug.Log("Anim Value -- " + animationValue);   
    }


    [Header("UI")]
    public TMP_Text velocityText;

    public void HandleUI()
    {
        float forwardVelocity = Mathf.Abs(rb.velocity.z);
        float velocityRoundedValue = Mathf.Round(forwardVelocity * 10.0f);
        velocityText.text = $"{velocityRoundedValue}";


        HandleGyro();


        TurnAutoAlignUI(InputManager.AutoAlign);
    }

    public void HandleGyro()
    {
        var eulerAngles = rotateImage.gameObject.transform.eulerAngles;
        rotateImage.gameObject.transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, transform.eulerAngles.z);
    }
}
