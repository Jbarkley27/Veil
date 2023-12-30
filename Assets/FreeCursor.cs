using System.Collections;
using System.Collections.Generic;
using MK.Toon;
using UnityEngine;
using UnityEngine.UI;

public class FreeCursor : MonoBehaviour
{
    public static bool InInnerBounds;
    public static bool InMiddleBounds;
    public static bool InOuterBounds;

    public InputManager inputManager;

    [Header("Reticle")]
    public Image reticle;
    public float reticleSpeedInput;
    public GameObject camFollow;
    public float offset;
    public Image freeCursorBounds;
    public float xScreen;
    public float yScreen;
    public float bottomScreenOffset;


    // Update is called once per frame
    void Update()
    {
        HandleReticle();


        float width = ((Screen.width / 2) + (Screen.width * xScreen)) - ((Screen.width / 2) - (Screen.width * xScreen));
        float height = ((Screen.height / 2) + (Screen.height * yScreen)) - ((Screen.height / 2) - (Screen.height * yScreen));
        freeCursorBounds.rectTransform.sizeDelta = new Vector2(width, height);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Inner Bounds"))
        {
            InInnerBounds = true;
        } else
        {
            InInnerBounds = false;
        }

        if (collision.CompareTag("Middle Bounds"))
        {
            InMiddleBounds = true;
        }
        else
        {
            InMiddleBounds = false;
        }

        if (collision.CompareTag("Outer Bounds"))
        {
            InOuterBounds = true;
        }
        else
        {
            InOuterBounds = false;
        }
    }


    public void HandleReticle()
    {
        if (inputManager.RawMovementInput.magnitude != 0)
        {


            Vector3 smoothMovement = Vector3.Lerp(gameObject.transform.position, new Vector3(
                                                                        gameObject.transform.position.x + inputManager.RawMovementInput.x,
                                                                        gameObject.transform.position.y + inputManager.RawMovementInput.y,
                                                                        0
                                                                        ),
                                                                        reticleSpeedInput * Time.deltaTime);



            Vector3 clampedPos = new Vector3(
                                            Mathf.Clamp(smoothMovement.x, (Screen.width / 2) - (Screen.width * xScreen), (Screen.width / 2) + (Screen.width * xScreen)),
                                            Mathf.Clamp(smoothMovement.y, (Screen.height / 2) - ((Screen.height * yScreen) - bottomScreenOffset), (Screen.height / 2) + (Screen.height * yScreen)),
                                            0);


            gameObject.transform.position = clampedPos;

        }

        MoveCameraFollowObject();
    }

    public void MoveCameraFollowObject()
    {
        Vector3 reticlePosition = transform.position;
        reticlePosition.z = offset;

        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(reticlePosition);



        camFollow.transform.position = screenToWorldPoint;
    }
}
