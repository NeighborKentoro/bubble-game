using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource popSfx;
    public AudioSource splashSfx;
    public AudioSource scoredSfx;
    public AudioSource flapSfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        EventManager.bubblePopEvent += this.PlayPopSfx;
        EventManager.scoreEvent += this.PlayScoreSfx;
        EventManager.flapEvent += this.PlayFlapSfx;
        EventManager.splashEvent += this.PlaySplashSfx;
    }

    void OnDisable()
    {
        EventManager.bubblePopEvent -= this.PlayPopSfx;
        EventManager.scoreEvent -= this.PlayScoreSfx;
        EventManager.flapEvent -= this.PlayFlapSfx;
        EventManager.splashEvent -= this.PlaySplashSfx;
    }

    void PlayPopSfx()
    {
        if (this.popSfx != null)
        {
            float lowPitch = 0.7f;
            float highPitch = 1.0f;
            float finalPitch = Random.Range(lowPitch, highPitch);
            this.popSfx.pitch = finalPitch;
            this.popSfx.Play();
        }
    }

    void PlaySplashSfx()
    {
        if (this.splashSfx != null)
        {
            float lowPitch = 0.85f;
            float highPitch = 1.0f;
            float finalPitch = Random.Range(lowPitch, highPitch);
            this.splashSfx.pitch = finalPitch;
            this.splashSfx.Play();
        }
    }

    void PlayScoreSfx(int playerId)
    {
        if (this.scoredSfx != null)
        {
            this.scoredSfx.Play();
        }
    }

    void PlayFlapSfx()
    {
        if (this.flapSfx != null)
        {
            float lowPitch = 0.38f;
            float highPitch = 0.50f;
            float finalPitch = Random.Range(lowPitch, highPitch);
            this.flapSfx.pitch = finalPitch;
            this.flapSfx.Play();
        }
    }
}
