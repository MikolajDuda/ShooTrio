using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float speed = 3;
    [SerializeField] private bool isOnGround;
    //private Animator anim;
    [SerializeField] private float torque = 10f;
    
    public bool hitted;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }   
        //      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        isOnGround = false;
        //anim.SetBool("isOnGround", false);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, transform.localScale.y / 2 + 0.1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != transform)
            {
                isOnGround = true;
                //anim.SetBool("isOnGround", true);
                break;
            }
        }
        
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 scale = transform.localScale;
        
        // Things needed to animations:
        //if (horizontal != 0)
        //{
            //anim.SetBool("isRunning", true);
        //}
        //else
        //{
            //anim.SetBool("isRunning", false);
        //}
        
        // Check if scale and horizontal have the same sign
        bool isSignTheSame = (scale.x >= 0 && horizontal >= 0 || scale.x <= 0 && horizontal <= 0);
        transform.localScale = isSignTheSame ?  
            new Vector3(scale.x, scale.y, scale.z) 
            : new Vector3(-scale.x,scale.y, scale.z);
        
        Vector2 translation = Vector2.right * (horizontal * speed * Time.fixedDeltaTime);
        
        if (translation == Vector2.zero)
        {
            return;
        }

        rb.position += translation;
/*
        if (hitted)
        {
            rb.AddTorque(torque);
        }
        */
    }
}
