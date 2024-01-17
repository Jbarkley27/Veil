
using System.Collections;
using Cinemachine;
using UnityEngine;


public class ScreenShakeManager : MonoBehaviour
{
    public static ScreenShakeManager Instance;
    [SerializeField] private CinemachineFreeLook cmFreeCam;

    [Header("Shake Settings")]
    public float amplitudeGain;
    public float frequemcyGain;
    public float shakeDuration;

    public struct ShakeProfile
    {
        public float amplitudeGain;
        public float frequencyGain;
        public float shakeDuration;

        public ShakeProfile(float amp, float fre, float dur)
        {
            this.amplitudeGain = amp;
            this.frequencyGain = fre;
            this.shakeDuration = dur;
        }
    }

    public ShakeProfile JumpProfile = new ShakeProfile(3.5f, 5, .15f);
    public ShakeProfile ShootProfile = new ShakeProfile(2f, 5, .1f);
    public ShakeProfile DashProfile = new ShakeProfile(4.5f, 5, .4f);
    public ShakeProfile DamagedProfile = new ShakeProfile(2.5f, 5, .3f);


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found a Screen Shake Manager object, destroying new one.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ResetScreenShake();
    }

    public void DoShake(ShakeProfile profile)
    {
        StartCoroutine(Shake(profile));
    }

    public IEnumerator Shake(ShakeProfile profile)
    {
        for (int i = 0; i < 3; i++)
        {
            cmFreeCam.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = profile.amplitudeGain;
            cmFreeCam.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = profile.frequencyGain;
        }


        yield return new WaitForSeconds(profile.shakeDuration / 2);


        ResetScreenShake();
    }

    public void ResetScreenShake()
    {
        for (int i = 0; i < 3; i++)
        {
            cmFreeCam.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            cmFreeCam.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
        }
    }
}
