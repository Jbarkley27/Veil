using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class FreeCursorCollision : MonoBehaviour
{
    
    public enum Bounds { DEADZONE, INNER, MIDDLE, OUTER};
    public static Bounds currentBounds = Bounds.DEADZONE;
    public Image deadBoundsImage;
    public Image innerBoundsImage;
    public Image middleBoundsImage;
    public Image outerBoundsImage;

    public CinemachineVirtualCamera vcam;
    public Transform defaultCamLookAt;

    void Update()
    {
        //Debug.Log($"Bounds {currentBounds}");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.CompareTag("DeadZone"))
        {
            currentBounds = Bounds.DEADZONE;
            HandleRenderingBoundsImages(deadBoundsImage.gameObject.name);
            //vcam.LookAt = null;
        }

        if (collision.CompareTag("Inner Bounds"))
        {
            currentBounds = Bounds.INNER;
            HandleRenderingBoundsImages(innerBoundsImage.gameObject.name);
            //vcam.LookAt = null;
        }
        

        if (collision.CompareTag("Middle Bounds"))
        {
            currentBounds = Bounds.MIDDLE;
            HandleRenderingBoundsImages(middleBoundsImage.gameObject.name);
            //vcam.LookAt = defaultCamLookAt;
        }
        

        if (collision.CompareTag("Outer Bounds"))
        {
            currentBounds = Bounds.OUTER;
            HandleRenderingBoundsImages(outerBoundsImage.gameObject.name);
            //vcam.LookAt = defaultCamLookAt;
        }
        
    }


    [Range(0,1)]
    public float nonEnteredBorderImageOpacity;

    public void HandleRenderingBoundsImages(string objectName)
    {
        if (objectName != deadBoundsImage.gameObject.name)
        {
            var tempColor = deadBoundsImage.color;
            tempColor.a = 0f;
            deadBoundsImage.color = tempColor;
        }
        else
        {
            var tempColor = deadBoundsImage.color;
            tempColor.a = nonEnteredBorderImageOpacity;
            deadBoundsImage.color = tempColor;
        }



        if (objectName != innerBoundsImage.gameObject.name)
        {
            var tempColor = innerBoundsImage.color;
            tempColor.a = 0f;
            innerBoundsImage.color = tempColor;
        }
        else
        {
            var tempColor = innerBoundsImage.color;
            tempColor.a = nonEnteredBorderImageOpacity;
            innerBoundsImage.color = tempColor;

        }


        if (objectName != middleBoundsImage.gameObject.name)
        {
            var tempColor = middleBoundsImage.color;
            tempColor.a = 0f;
            middleBoundsImage.color = tempColor;
        }
        else
        {
            var tempColor = middleBoundsImage.color;
            tempColor.a = nonEnteredBorderImageOpacity;
            middleBoundsImage.color = tempColor;
        }



        if (objectName != outerBoundsImage.gameObject.name)
        {
            var tempColor = outerBoundsImage.color;
            tempColor.a = 0f;
            outerBoundsImage.color = tempColor;
        }
        else
        {
            var tempColor = outerBoundsImage.color;
            tempColor.a = nonEnteredBorderImageOpacity;
            outerBoundsImage.color = tempColor;
        }
    }

    public static bool IsInBounds(Bounds bounds)
    {
        return (currentBounds == bounds);
    }

    
}
