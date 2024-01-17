//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpriteController : MonoBehaviour
//{
//    public Transform spriteFollowPosition;
//    public float SpriteFollowSpeed;
//    public GameObject player;
//    public float SpriteRotationBaseSpeed;
//    public float SpriteRotationShootSpeed;
//    public GameObject SpriteBody;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        transform.position = Vector3.Lerp(transform.position, spriteFollowPosition.position, Time.deltaTime * SpriteFollowSpeed);
//        HandleRotation();
//    }

//    public void HandleRotation()
//    {
//        if (InputManager.instance.ShootingPrimary || InputManager.instance.ShootingSecondary)
//        {
//            SpriteBody.transform.rotation = Quaternion.Lerp(SpriteBody.transform.rotation, Camera.main.transform.rotation, Time.deltaTime * SpriteRotationShootSpeed);
//        }

//        else
//        {
//            SpriteBody.transform.rotation = Quaternion.Lerp(SpriteBody.transform.rotation, player.transform.rotation, Time.deltaTime * SpriteRotationBaseSpeed);
//        }
//    }
//}
