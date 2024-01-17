//using UnityEngine;


//public class GlobalDataReference : MonoBehaviour
//{
//    public static GlobalDataReference instance { get; private set; }    

//    [Header("Player")]
//    public Transform player;

//    [Header("Enemy Values")]
//    public Canvas EnemyCanvas;
//    public GameObject EnemyHealthPrefab;

//    public ReticleManager reticleManager;

//    private void Awake()
//    {
//        if (instance != null)
//        {
//            Debug.LogError("Found an GlobalDataReference object, destroying new one.");
//            Destroy(gameObject);
//            return;
//        }
//        instance = this;
//        DontDestroyOnLoad(gameObject);
//    }
//}

