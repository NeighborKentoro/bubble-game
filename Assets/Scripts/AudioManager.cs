using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource popSfx;
    public AudioSource splashSfx;
    public AudioSource scoredSfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EventManager.BubblePop();
        }
    }

    void OnEnable()
    {
        EventManager.bubblePopEvent += this.PlayPopSfx;
        EventManager.scoreEvent += this.PlayScoreSfx;
    }

    void OnDisable()
    {
        EventManager.bubblePopEvent -= this.PlayPopSfx;
        EventManager.scoreEvent -= this.PlayScoreSfx;
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

    void PlayScoreSfx(int playerId)
    {
        if (this.scoredSfx != null)
        {
            this.scoredSfx.Play();
        }
    }
}
