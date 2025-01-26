using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
