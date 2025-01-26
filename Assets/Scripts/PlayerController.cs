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
    [SerializeField]AnimatorController animController;
    [SerializeField]PhysicsMaterial2D normalMaterial;
    [SerializeField]PhysicsMaterial2D bounceMaterial;
    [SerializeField]Vector2 colliderSizeFoating = new Vector2(0.8f, 1.5f);
    [SerializeField]Vector2 colliderSizeGrounded = new Vector2(1.5f, 0.7f);

    private Rigidbody2D rb;
    private CapsuleCollider2D collider2d;
    private Vector2 moveInput;
    [SerializeField]private bool isFloating;
    private bool isGrounded;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<CapsuleCollider2D>();
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
        collider2d = GetComponent<CapsuleCollider2D>();
        SetBalloonAttachment(isFloating);
    }

    void Move(Vector2 direction){
        animController.AnimIsGrounded(!isFloating);
        if(isFloating){
            animController.AnimFloatdDirection(direction.x);
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
                animController.AnimBlow();
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
            collider2d.sharedMaterial = bounceMaterial;
            collider2d.direction = CapsuleDirection2D.Vertical;
            collider2d.size = new Vector2(colliderSizeFoating.x, colliderSizeFoating.y);
            rb.linearDamping = floatDamping;
        }else{
            collider2d.sharedMaterial = normalMaterial;
            collider2d.direction = CapsuleDirection2D.Horizontal;
            collider2d.size = new Vector2(colliderSizeGrounded.x, colliderSizeGrounded.y);
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
