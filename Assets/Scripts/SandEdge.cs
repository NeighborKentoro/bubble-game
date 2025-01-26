using UnityEngine;

public class SandEdge : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if colliding with player layer
        if (collision.collider.gameObject.layer == 9)
        {
            // give player their bubble ("balloon")
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.SetBalloonAttachment(true);
        }
    }
}
