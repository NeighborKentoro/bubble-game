using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerId;

    public int GetPlayerId()
    {
        return playerId;
    }

    public void SetPlayerId(int playerId)
    {
        this.playerId = playerId;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if colliding with opponents bubble
        if (collision.collider.gameObject.layer == 7)
        {
            // trigger bubble pop event            
            EventManager.BubblePop();
            collision.collider.gameObject.GetComponent<Bubble>().Pop();
        }
    }
}
