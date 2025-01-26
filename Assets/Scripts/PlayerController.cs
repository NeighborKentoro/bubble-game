using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]InputReader input;
    [SerializeField]float floatDamping = 10f;
    [SerializeField]float flapForce = 10f;
    [SerializeField]float jumpForce = 5f;
    [SerializeField]float horizontalFloatForce = 15f;
    [SerializeField]float horizontalWalkForce = 5f;
    [SerializeField]float offsetToGround = 0f;
    [SerializeField]LayerMask groundLayer;
    [SerializeField]
    private float maxSpeed = 100f;


    private Rigidbody2D rb;
    private Vector2 moveInput;
    // public bool BalloonAttached {
    //     get => isFloating;
    //     set{
    //         isFloating = value;
    //         SetPlayerState(isFloating);
    //     }
    // }
    [SerializeField]private bool isFloating;
    private bool isGrounded;

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

    void OnValidate(){
        rb = GetComponent<Rigidbody2D>();
        SetBalloonAttachment(isFloating);
    }

    void Move(Vector2 direction){
        if (isFloating){
            rb.AddForce(horizontalFloatForce * direction);
        }else{
            rb.AddForce(horizontalWalkForce * direction);
        }
    }

    Vector2 CalculateHorzontalForce(){
        return new Vector2(moveInput.x, 0f);
    }

    void OnFlap(bool isPressed){
        if (isPressed)
        {
            if (isFloating)
            {
                rb.AddForce(flapForce * Vector2.up, ForceMode2D.Impulse);
            }
            else
            {
                if (IsGrounded())
                {
                    rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void SetBalloonAttachment(bool floating){
        isFloating = floating;       
        if(floating){
            rb.linearDamping = floatDamping;
        }else{
            rb.linearDamping = 0f;
        }
    }

    bool IsGrounded(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, offsetToGround + 0.1f, groundLayer);
        return isGrounded;
    }

    public void SetInputReader(InputReader inputReader)
    {
        input = inputReader;
    }

}
