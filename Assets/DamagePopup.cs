//using UnityEngine;
//using DamageNumbersPro;

//public class DamagePopup : MonoBehaviour
//{
//    //Assign prefab in inspector.
//    public DamageNumber numberPrefab;
//    public Transform followTransform;


//    public void ShowDamage(float damage)
//    {
//        //Spawn new popup at transform.position with a random number between 0 and 100.
//        DamageNumber damageNumber = numberPrefab.Spawn(transform.position, damage, followTransform);
//        damageNumber.transform.SetParent(GlobalDataReference.instance.EnemyCanvas.transform);
//    }
//}
