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
    }

    void OnDisable()
    {
        EventManager.scoreEvent -= this.ScorePoint;
    }

    void ScorePoint(int playerId)
    {
        if (playerId == this.playerId && this.scoreIndex < this.scoreImages.Length)
        {
            this.scoreImages[this.scoreIndex].enabled = true;
            this.scoreIndex++;
        }
    }
}
