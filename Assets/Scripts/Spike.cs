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
        // bubble has collided with spike
        if (collision.collider.gameObject.tag == "Bubble")
        {
            // trigger bubble pop event
        }
    }
}
