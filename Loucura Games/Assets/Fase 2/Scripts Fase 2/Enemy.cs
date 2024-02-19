using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    public float minHeight;
    public float maxHeight;

    private Rigidbody rb;
    private Animator anim;
    private Transform groundCheck;
    private bool onGround;
    private bool facingRight = false;
    private Transform target;
    private bool isDead = false;
    private float zForce;
    private float walkTimer;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        target = FindObjectOfType<PlayerFase2>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Grounded", onGround);

        facingRight = (target.position.x < transform.position.x) ? false : true;
        if (facingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        walkTimer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            Vector3 targetDistance = target.position - transform.position;
            float hForce = targetDistance.x / Mathf.Abs(targetDistance.x);

            if (walkTimer >= Random.Range(1f, 2f))
            {
                zForce = Random.Range(-1, 2);
                walkTimer = 0;
            }

            if(Mathf.Abs(targetDistance.x) < 1.5f)
            {
                hForce = 0;
            }

            rb.velocity = new Vector3(hForce * currentSpeed, 0, zForce * currentSpeed);

            anim.SetFloat("Speed", Mathf.Abs(currentSpeed));
        }
        rb.position = new Vector3(
                rb.position.x,
                rb.position.y,
                Mathf.Clamp(rb.position.z, minHeight, maxHeight));
    }
    void ZeroSpeed()
    {
        currentSpeed = 0;
    }

    void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }
}
