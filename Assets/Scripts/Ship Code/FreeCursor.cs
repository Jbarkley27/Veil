using System.Collections;
using System.Collections.Generic;
using MK.Toon;
using UnityEngine;
using UnityEngine.UI;

public class FreeCursor : MonoBehaviour
{
    public InputManager inputManager;

    [Header("Reticle")]
    public Image reticle;
    public GameObject reticleGameObject;
    public float reticleSpeedInput;
    public Image freeCursorBounds;
    public Image baseCrossHair;

    [Range(0,1)]
    public float xScreenBoundsPercentage;

    [Range(0, 1)]
    public float yScreenBoundsPercentage;

    public float bottomScreenOffset;
    public float cursorSpeedMultiplier;


    [Header("Cam Follow Object")]
    public GameObject camFollow;
    public float camFollowOffset;

    // Update is called once per frame
    void Update()
    {
        HandleReticle();


        float width = ((Screen.width / 2) + (Screen.width * xScreenBoundsPercentage)) - ((Screen.width / 2) - (Screen.width * xScreenBoundsPercentage));
        float height = ((Screen.height / 2) + (Screen.height * yScreenBoundsPercentage)) - ((Screen.height / 2) - (Screen.height * yScreenBoundsPercentage));
        freeCursorBounds.rectTransform.sizeDelta = new Vector2(width, height);

        HandleBaseReticle();
    }



    public static Vector3 clampedPos;
    public void HandleReticle()
    {
        if (InputManager.RawKestralMovementInput.magnitude != 0)
        {
            Vector3 smoothMovement = Vector3.Lerp(reticleGameObject.transform.position, new Vector3(
                                                                        reticleGameObject.transform.position.x + InputManager.RawKestralMovementInput.x * cursorSpeedMultiplier,
                                                                        reticleGameObject.transform.position.y + InputManager.RawKestralMovementInput.y * cursorSpeedMultiplier,
                                                                        0
                                                                        ),
                                                                        reticleSpeedInput * Time.deltaTime);



            clampedPos = new Vector3(
                                            Mathf.Clamp(smoothMovement.x, (Screen.width / 2) - (Screen.width * xScreenBoundsPercentage), (Screen.width / 2) + (Screen.width * xScreenBoundsPercentage)),
                                            Mathf.Clamp(smoothMovement.y, (Screen.height / 2) - ((Screen.height * yScreenBoundsPercentage) - bottomScreenOffset), (Screen.height / 2) + (Screen.height * yScreenBoundsPercentage)),
                                            0);


            reticleGameObject.transform.position = clampedPos;

        }

        MoveCameraFollowObject();
    }

    public static bool IsLeftSideScreen()
    {
        float middleX = Screen.width / 2;

        if (clampedPos.x < middleX)
        {
            return true;
        }

        return false;
    }

    public static bool IsBottomOfScreen()
    {
        float middleHeight = Screen.height / 2;

        if (clampedPos.y < middleHeight)
        {
            return true;
        }

        return false;
    }

    [Header("Base Reticle")]
    public float defaultReticleSize = 50f;
    public float minimizedReticleSize = 30f;
    private float targetState;
    public float baseReticleSpeed;

    [Range(0, 150)]
    public float xBaseReticleScreenWidthBounds;

    [Range(0, 150)]
    public float yBaseReticleScreenWidthBounds;

    [Range(0, 1)]
    public float inactiveBaseReticleOpacity;

    public void HandleBaseReticle()
    {
        int screenWidth = Screen.width / 2;
        int screenHeight = Screen.height / 2;

        bool inXBounds = false;
        bool inYBounds = false;

        if (reticleGameObject.transform.position.x > (screenWidth - xBaseReticleScreenWidthBounds) && reticleGameObject.transform.position.x < (screenWidth + xBaseReticleScreenWidthBounds))
        {
            inXBounds = true;
        }
        else
        {
            inXBounds = false;
        }

        if (reticleGameObject.transform.position.y > (screenHeight - yBaseReticleScreenWidthBounds) && reticleGameObject.transform.position.y < (screenHeight + yBaseReticleScreenWidthBounds))
        {
            inYBounds = true;
        }
        else
        {
            inYBounds = false;
        }

        if (inXBounds && inYBounds)
        {
            targetState = minimizedReticleSize;
            var tempColor = baseCrossHair.color;
            tempColor.a = .9f;
            baseCrossHair.color = tempColor;
        } else
        {
            targetState = defaultReticleSize;
            var tempColor = baseCrossHair.color;
            tempColor.a = inactiveBaseReticleOpacity;
            baseCrossHair.color = tempColor;
        }

        baseCrossHair.rectTransform.sizeDelta = Vector3.Lerp(baseCrossHair.rectTransform.sizeDelta, new Vector2(targetState, targetState), baseReticleSpeed * Time.deltaTime);
    }

    public static float GetAnimationSpeed()
    {
        float halfScreenWidth = Screen.width / 2;

        if (clampedPos.x > halfScreenWidth)
        {
            // right side

            float test = clampedPos.x - halfScreenWidth;

            return test / halfScreenWidth;
        }

        else
        {
            // left side

            float test2 = halfScreenWidth - clampedPos.x;

            return test2 / halfScreenWidth;
        }
    }


    public Transform shadowCamLookAt;
    public float yOffset;
    public void MoveCameraFollowObject()
    {
        Vector3 reticlePosition = reticleGameObject.transform.position;
        reticlePosition.z = camFollowOffset;


        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(reticlePosition);

        

        camFollow.transform.position = screenToWorldPoint;

        reticlePosition.y += yOffset;

        screenToWorldPoint = Camera.main.ScreenToWorldPoint(reticlePosition);



        shadowCamLookAt.transform.position = screenToWorldPoint;
    }
}
