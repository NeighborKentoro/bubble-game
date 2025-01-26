using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerId;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public int GetPlayerId()
    {
        return playerId;
    }

    public void SetPlayerId(int playerId)
    {
        this.playerId = playerId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
