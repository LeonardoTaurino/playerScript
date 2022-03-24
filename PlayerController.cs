using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;

    public Transform platformCheck;
    public float platformCheckRadius;
    public LayerMask whatIsPlatform;
    private bool platform;
    private Animator anim;

    void Start() 
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() //fixedupdate è preferibile con tutto quello che ha a che fare con fisica
    {
        platform = Physics2D.OverlapCircle(platformCheck.position, platformCheckRadius, whatIsPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && platform) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpPower);
        }
        if (Input.GetKey(KeyCode.D) && platform)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A) && platform)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        anim.SetFloat("MoveSpeed", Math.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", platform);
        // flip player
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (GetComponent<Rigidbody2D>().velocity.x < 0) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
}
