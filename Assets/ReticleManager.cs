//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ReticleManager : MonoBehaviour
//{

//    //public Image innerReticle;
//    public Image outerReticle;
//    public GameObject enemyAimedAtReticle;
//    public GameObject damageReticle;


//    Coroutine damageCo;

//    private void Start()
//    {
//        enemyAimedAtReticle.SetActive(false);
//        damageReticle.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        ShowAimAtEnemyReticle();
//        HideOuterReticle();
//    }

//    public void HideOuterReticle()
//    {
//        //hide outer reticle if zoomed
//        if (InputManager.instance.FocusPressed)
//        {
//            outerReticle.gameObject.SetActive(false);
//        }
//        else
//        {
//            outerReticle.gameObject.SetActive(true);
//        }
//    }

//    public void ShowAimAtEnemyReticle()
//    {
//        if (damageReticle.activeSelf) return;

//        if (PlayerAimManager.instance.CheckIfEnemy())
//        {
//            enemyAimedAtReticle.SetActive(true);
//        }
//        else
//        {
//            enemyAimedAtReticle.SetActive(false);
//        }
//    }


//    public void ShowDamageReticle()
//    {
//        if (damageCo != null) StopCoroutine(damageCo);

//        damageCo = StartCoroutine(FlashReticle());
//    }


//    public IEnumerator FlashReticle()
//    {
//        damageReticle.SetActive(true);

//        yield return new WaitForSeconds(.1f);

//        damageReticle.SetActive(false);
//    }
//}
