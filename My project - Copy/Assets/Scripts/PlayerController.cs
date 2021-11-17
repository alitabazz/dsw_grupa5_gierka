using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float rayDistance = 0.1f;


    private bool canDoubleJump;
    private bool isGrounded;
    
    private void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void Update()
    {
        Jump();
        ExtraJump();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Pickup pickup = collider.GetComponent<Pickup>();
        
        if (pickup != null)
        {
            pickup.Collect();
        }
    }
    
    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 6f;
        }
        else
        {
            movementSpeed = 3f;
        }
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
        }
    }

    private void ExtraJump()
    {
        
        if(Input.GetButtonDown("Jump") && isGrounded == false && canDoubleJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canDoubleJump = false;
       
        }

        
    }

    private void CheckGround()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(
            rayOrigin.position,
            Vector2.down,
            rayDistance);

        isGrounded = raycastHit.collider != null;
        
        if (isGrounded)
        {
            Debug.Log(raycastHit.collider.name);
            canDoubleJump = true;
        }
        
    }
}
