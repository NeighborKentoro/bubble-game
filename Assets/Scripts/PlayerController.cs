using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]InputReader input;
    [SerializeField]float flapForce = 10f;
    [SerializeField]float horizontalForce = 2f;


    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.Move += direction => moveInput = direction;
        input.Flap += OnFlap;
        input.EnablePlayerActions();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(CalculateHorzontalForce());
    }

    void Move(Vector2 direction){
        rb.AddForce(horizontalForce * direction);
    }

    Vector2 CalculateHorzontalForce(){
        return new Vector2(moveInput.x, 0f);
    }

    void OnFlap(bool isPressed){
        rb.AddForce(flapForce * Vector2.up, ForceMode2D.Impulse);
    }

}
