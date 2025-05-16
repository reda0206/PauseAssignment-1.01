using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // a holder for the rigidbody, which we will manipulate in order to move the player
    private Rigidbody2D rb;
    // is the player on the ground?
    private bool isGrounded;
    // how fast is the player moving?
    public float speed = 5f;
    // how high are they jumping / how much force do they jump with?
    public float jumpForce = 5f;

    public float noiseCooldown = 1f;
    private float lastNoiseTime = -Mathf.Infinity;

    // our audio source for the SFX!
    public AudioSource noiseSource;
    // the sound we play!
    public AudioClip noiseClip;

    // Start is called before the first frame update
    void Start()
    {
        // automatically assign the rigidbody on startup
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per 0.02 seconds (50x per second)
    void FixedUpdate()
    {
        // moving left and right by getting the Horizontal movement axis
        float moveInput = Input.GetAxis("Horizontal");
        // we are directly relating our horizontal velocity of our rigidbody by setting rb.velocity.x to "moveInput * speed"!
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // jumping
        // if the Jump axis is > 0 (if we're pressing the Spacebar), AND if the player is grounded...
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            // then set the vertical velocity to the jump force instantaneously
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastNoiseTime >= noiseCooldown)
            {
                noiseSource.PlayOneShot(noiseClip);
                lastNoiseTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // OUR PAUSE MENU GOES HERE!
        }
    }

    // when we start touching another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if it has the ground tag. if it does...
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ...then set isGrounded to true!
            isGrounded = true;
        }
    }

    // when we STOP touching another collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // is the other object tagged with Ground? if so...
        if (collision.gameObject.CompareTag("Ground"))
        {
            // then set isGrounded to false, because we stopped touching the ground!
            isGrounded = false;
        }
    }
}
