using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // bubble has collided with spike (7 is bubble layer)
        if (collision.collider.gameObject.layer == 7)
        {
            // trigger bubble pop event            
            collision.collider.gameObject.GetComponent<Bubble>().Pop();
            EventManager.BubblePop();
        }
    }
}
