using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KestralInput : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceFrontFollowObject();
        //LookAtPoint();
    }

    private void FixedUpdate()
    {
        LookAtPoint();
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
    public void LookAtPoint()
    {

        HandleRoll();
        var localTarget = transform.InverseTransformPoint(camFollowObject.transform.position);

        var angleY = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        var angleX = Mathf.Atan2(localTarget.y, localTarget.z) * Mathf.Rad2Deg * -1f;


        Vector3 eulerAngleVelocity = new Vector3(angleX * GetRotationSpeed(), angleY * GetRotationSpeed(), playerZRotInput * rollMult);
        //Debug.Log($"Angle -- {eulerAngleVelocity}");
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

        //deltaRotation.z = 0.0f;
        rb.MoveRotation(rb.rotation * deltaRotation);

        var eulerAngles = rotateImage.gameObject.transform.eulerAngles;
        rotateImage.gameObject.transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, transform.eulerAngles.z);
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

    public float frontOffset;
    public GameObject frontFollowObject;

    public void PlaceFrontFollowObject()
    {
        frontFollowObject.transform.position = rb.transform.position +
            rb.transform.forward * frontOffset;

    }

    [Header("Thrust")]
    public float thrustMultiplier;
    public void HandleThrust()
    {
        if (InputManager.ThrustInput.sqrMagnitude != 0)
        {
            Vector3 thrustVector = new Vector3(-InputManager.ThrustInput.x, 0, -InputManager.ThrustInput.y);
            rb.AddForce(thrustMultiplier * Time.deltaTime * thrustVector, ForceMode.VelocityChange);
        }
    }
}
