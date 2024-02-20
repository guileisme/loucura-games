using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFase2 : MonoBehaviour
{
    public float maxSpeed = 4;
    public float jumpForce = 4000;
    public float minHeight, maxHeight;
    public int maxHealth = 10;
    public string playerName;
    public Sprite playerImage;

    private int currentHealth;
    private float currentSpeed;
    private Rigidbody rb;
    private Animator anim;
    private Transform groundCheck;
    private bool onGround;
    private bool isDead = false;
    private bool facingRight = true;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        currentSpeed = maxSpeed;
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        anim.SetBool("OnGround", onGround);


        if(Input.GetButtonDown("Pulo") && onGround)
        {
            jump = true;
        }

        if (Input.GetButtonDown("AtackJ"))
        {
            anim.SetTrigger("attackJ");
        }
        if (Input.GetButtonDown("AtackK"))
        {
            anim.SetTrigger("attackK");
        }
        if (Input.GetButtonDown("AtackL"))
        {
            anim.SetTrigger("attackL");
        }
    }
    private void FixedUpdate()
    {
        if(!isDead)
        {
            float h = Input.GetAxis("Horizontal");

            float z = Input.GetAxis("Vertical");

            if (!onGround)
            {
                z = 0;
            }

            rb.velocity = new Vector3(h * currentSpeed, rb.velocity.y, z * currentSpeed);

            if (onGround)
            {
                anim.SetFloat("speed-player", Mathf.Abs(rb.velocity.magnitude));
            }

            if(h > 0 && !facingRight)
            {
                Flip();
            }
            else if(h < 0 && facingRight)
            {
                Flip();
            }

            if (jump)
            {
                jump = false;
                rb.AddForce(Vector3.up * jumpForce);
            }
            float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
            float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minWidth + 1, maxWidth - 1),
                rb.position.y,
                Mathf.Clamp(rb.position.z, minHeight, maxHeight));

        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void ZeroSpeed()
    {
        currentSpeed = 0;
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }

    public void TookDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            FindObjectOfType<UIManager>().UpdateHealth(currentHealth);
        }
    }
}
