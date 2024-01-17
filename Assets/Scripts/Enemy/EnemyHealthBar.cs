//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class EnemyHealthBar : MonoBehaviour
//{
//    public GameObject EnemyToFollow;
//    public HitFlashEffect hitFlash;

//    [Header("Base")]
//    public EnemyBase enemyBase;
//    public EnemyDatabase.EnemyData enemyHealthData;

//    [Header("UI")]
//    public Slider enemyHealthSlider;
//    public Slider enemyBarrierSlider;
//    public DamagePopup dmgPopup;

//    [Header("Settings")]
//    public float currentHealth;
//    public float currentBarrier = 0;
//    private float currentT = 0f;
//    public float healthSliderDropSpeed = 100f;
//    public bool isDead = false;


//    // Start is called before the first frame update
//    void Start()
//    {
//        transform.SetParent(GlobalDataReference.instance.EnemyCanvas.transform);
//        SetupHealth();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (EnemyToFollow) transform.position = Camera.main.WorldToScreenPoint(EnemyToFollow.transform.position);
//        DeathWatcher();
//        UpdateUISliders();
//    }

//    public void AssignEnemy(GameObject enemyToFollow)
//    {
//        EnemyToFollow = enemyToFollow;
//    }

//    public void SetupHealth()
//    {
//        // reads its health and barrier values from enemy data base
//        enemyHealthData = EnemyDatabase.GetEnemyData(enemyBase.type);

//        // setup health
//        currentHealth = enemyHealthData.maxHealth;
//        enemyHealthSlider.maxValue = currentHealth;
//        enemyHealthSlider.value = currentHealth;

//        // setup barrier
//        if (enemyHealthData.hasBarrier)
//        {
//            enemyBarrierSlider.maxValue = enemyHealthData.maxBarrier;
//            currentBarrier = enemyHealthData.maxBarrier;
//        }
//        else
//        {
//            // hide the barrier UI if we dont have one
//            enemyBarrierSlider.gameObject.SetActive(false);
//        }
//    }

//    public void TakeDamage(float damage)
//    {

//        // make enemy flash
//        if (isDead) return;
//        if (hitFlash != null) hitFlash.Flash();
//        dmgPopup.ShowDamage(damage);

//        // enemy has barrier
//        if (enemyHealthData.hasBarrier)
//        {

//            float difference = currentBarrier - damage;

//            // enemy still have barrier left
//            if (currentBarrier > 0)
//            {
//                // this means that we don't have to cut into health yet
//                if (difference >= 0)
//                {
//                    currentBarrier = difference;

//                }

//                // this means we need to take some from barrier and health
//                else
//                {
//                    currentHealth -= damage;
//                }


//                // todo check here if currentBarrier is <= 0 so we can play cool barrier break sound
//            }

//            // we dont have barrier and we should subtract from health
//            else
//            {
//                currentHealth -= damage;
//            }

//        }

//        // enemy does not have barrier
//        else
//        {
//            currentHealth -= damage;

//            if (currentHealth <= 0)
//            {
//                isDead = true;
//            }
//        }
//    }

//    public void DeathWatcher()
//    {
//        if (isDead)
//        {
//            Debug.Log("I have died");

//            // reset color so we don't have the enemy die white
//            hitFlash.ResetColors();

//            // todo spawn explosion here , death sound, explosion sound
//        }
//    }

//    public void UpdateUISliders()
//    {
//        // barrier
//        if (enemyHealthData.hasBarrier)
//        {
//            float barrierLeft = Mathf.SmoothDamp(enemyBarrierSlider.value, currentBarrier, ref currentT, healthSliderDropSpeed * Time.deltaTime);
//            enemyBarrierSlider.value = barrierLeft;
//        }


//        // health
//        float healthLeft = Mathf.SmoothDamp(enemyHealthSlider.value, currentHealth, ref currentT, healthSliderDropSpeed * Time.deltaTime);
//        enemyHealthSlider.value = healthLeft;
//    }
//}
