using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Tooltip("The Id of the player this score text is tracking")]
    public int playerId = 1;

    private int scoreIndex = 0;

    private Image[] scoreImages;

    void Start()
    {
        this.scoreImages = this.GetComponentsInChildren<Image>();
    }

    void OnEnable()
    {
        EventManager.scoreEvent += this.ScorePoint;
        EventManager.restartGameEvent += this.ResetScore;
    }

    void OnDisable()
    {
        EventManager.scoreEvent -= this.ScorePoint;
        EventManager.restartGameEvent -= this.ResetScore;
    }

    void ScorePoint(int playerId)
    {
        if (playerId == this.playerId && this.scoreIndex < this.scoreImages.Length)
        {
            this.scoreImages[this.scoreIndex].enabled = true;
            this.scoreIndex++;
        }
    }

    void ResetScore()
    {
        for(int i = 0; i < this.scoreImages.Length; i++)
        {
            this.scoreImages[i].enabled = false;
        }
        scoreIndex = 0;
    }
}
