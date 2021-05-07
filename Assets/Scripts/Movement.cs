using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float speed = 3;

    private bool isOnGround;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        isOnGround = false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, transform.localScale.y / 2 + 0.1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != transform)
            {
                isOnGround = true;
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
        Vector2 translation = Vector2.right * (horizontal * speed * Time.fixedDeltaTime);

        if (translation == Vector2.zero)
        {
            return;
        }
        
        //rb.AddForce(translation);
        rb.position += translation;

    }
}
