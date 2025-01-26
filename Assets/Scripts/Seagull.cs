using UnityEngine;

public class Seagull : MonoBehaviour
{

    [SerializeField]float speed = 5f;
    private Vector3 dir = Vector3.right;
    private bool isActive;
    private SpriteRenderer sprite;

    void Awake(){
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ActivateSeagull(Vector3 direction,bool active = true, float despawnTime = 10f){
        if(direction == Vector3.left){
            sprite.flipX = true;
            dir = direction;
        }else{
            sprite.flipX = false;
            dir = direction;
        }
        isActive = active;
        Destroy(gameObject, despawnTime);
    }


    void Update(){
        if(isActive){
            transform.position += speed * Time.deltaTime * dir;
        }
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
