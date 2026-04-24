using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    PlayerInput playerInput;
    Rigidbody2D rb;


    public LayerMask Ground;
    public LayerMask Enemy;

    RaycastHit2D hit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var move = playerInput.actions["Move"].ReadValue<Vector2>();

        rb.linearVelocityX = move.x * speed;

        if (playerInput.actions["Jump"].WasPressedThisFrame()&&JumpControl())
        {
            rb.linearVelocityY = jumpSpeed;
        }

        if(JumpAttack())
        {
            Debug.Log("aa");
        }

        Debug.DrawRay(transform.position, Vector2.down, Color.red);
    }

    private bool JumpControl()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, Ground);
        return hit.collider !=null;
    }

    private bool JumpAttack()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, Enemy);
        return hit.collider !=null;
    }
}
