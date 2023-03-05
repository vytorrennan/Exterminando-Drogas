using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemment : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D fullFriction;
    [SerializeField] private PhysicsMaterial2D noFriction;
    private new Collider2D collider;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator Anim;
    public float speed;
    public float jump;
    public float jumpSlope;
    public bool slopeJump = false;
    public float dash;
    public int side = 1;
    public GameObject jumpDustPrefab;
    public GameObject dashPrefab;
    public bool slope = false;
    //private bool InAir = false;
    private float jumpBufferTime = 0.2f;
    private float jumBufferCounter;
    private float dirX;
    private bool facingRight = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Jump();
        Dash();
        //Debug.Log(rb.velocity);
    }

    private void Move() {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        UpdateAnimationUpdate();
    }

    private void Flip()
    {
        gameObject.transform.Rotate(new Vector3(0, 180, 0));

        facingRight = !facingRight;
    }

    private void UpdateAnimationUpdate(){
        if (dirX != 0)
        {
            Anim.SetBool("isRunning", true);
            rb.sharedMaterial = noFriction;
            collider.sharedMaterial = noFriction;
        }
        else
        {
            Anim.SetBool("isRunning", false);
            rb.sharedMaterial = fullFriction;
            collider.sharedMaterial = fullFriction;
        }
        if (!facingRight && dirX > 0f)
        {
            Flip();
            side *= -1;
        }
        else if (facingRight && dirX < 0f)
        {
            Flip();
            side *= -1;
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y/2) < this.gameObject.transform.position.y && this.gameObject.transform.position.y < (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y / 2)+1.903)
        {
            InAir = false;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y / 2) < this.gameObject.transform.position.y && this.gameObject.transform.position.y < (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y / 2) + 1.903)
        {
            InAir = true;
        }
    }
    */
    
    
    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    

    private void Jump()
    {
        bool jumpPressed = Input.GetButtonDown("Jump");

        if (jumpPressed)
        {
            jumBufferCounter = jumpBufferTime;
        }
        else
        {
            jumBufferCounter -= Time.deltaTime;
        }
        

        if(jumBufferCounter > 0f && isGrounded() && !slopeJump)
        {
            print("Jump NOT Slope");
            rb.AddForce(new Vector2(rb.velocity.x, jump * Time.deltaTime)); //40000
            // rb.velocity = new Vector2(rb.velocity.x, jump * Time.deltaTime); //750
            Instantiate(jumpDustPrefab, this.transform.position, this.transform.rotation);
            //InAir = true;
            jumBufferCounter = 0f;
        }

        if (jumBufferCounter > 0f && isGrounded() && slopeJump)
        {
            print("Jump Slope");
            // rb.AddForce(new Vector2(rb.velocity.x, jump * Time.deltaTime)); //40000
            rb.velocity = new Vector2(rb.velocity.x, jumpSlope * Time.deltaTime); //750
            Instantiate(jumpDustPrefab, this.transform.position, this.transform.rotation);
            //InAir = true;
            jumBufferCounter = 0f;
        }
    }

    private void Dash()
    {
        bool dashPressed = Input.GetButtonDown("Fire3");



        if (!slope && dashPressed)
        {
            rb.AddForce(new Vector2((dash * side) * Time.deltaTime, rb.velocity.y)); //250000
            //rb.velocity = new Vector2((dash * side) * Time.deltaTime, rb.velocity.y); //10000
            Instantiate(dashPrefab, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);
        }
    }
}
