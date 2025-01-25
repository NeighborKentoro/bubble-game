using UnityEngine;

public class Token : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player collides with token
        if (collision.gameObject.layer == 9)
        {
            // player scored event
            EventManager.PlayerScored(collision.gameObject.GetComponent<Player>().GetPlayerId());

            // destroy token
            Object.Destroy(this.gameObject);
        }
    }

}
