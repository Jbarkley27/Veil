//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyBase : MonoBehaviour
//{
//    public GameObject UIPlacementPosition;
//    public EnemyHealthBar enemyHealth;
//    public EnemyDatabase.EnemyType type;
    

//    // Start is called before the first frame update
//    void Start()
//    {
//        GameObject HealthUI = Instantiate(GlobalDataReference.instance.EnemyHealthPrefab);
//        enemyHealth = HealthUI.GetComponent<EnemyHealthBar>();
//        enemyHealth.AssignEnemy(UIPlacementPosition);
//        enemyHealth.hitFlash = GetComponent<HitFlashEffect>();
//        enemyHealth.enemyBase = GetComponent<EnemyBase>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
