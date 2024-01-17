using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    float horizontalInput;

    bool onFloor;
    bool wallBumping;
    bool levelended = false;

    Rigidbody2D rb;

    Animator anim;

    Vector2 rbMovement;

    Vector3 movement;

    [SerializeField] LevelManager levelmanager;

    [SerializeField] Vector3 checkpoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 3f;
    }

    private void Update()
    {
        if (levelended)
        {
            return;
        }

        // Move left or right
        if (!wallBumping)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            onFloor = false;
        }

        //animation
        if (rb.velocity.y > 0 && onFloor == false)
        {
            //implement when animations are made
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", false);
            anim.SetBool("Jumping", true);
        }
        else if (horizontalInput == 0)
        {
            //implement when animations are made
            anim.SetBool("Idle", true);
            anim.SetBool("Walking", false);
            anim.SetBool("Jumping", false);
        }
        else
        {
            //implement when animations are made
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", true);
            anim.SetBool("Jumping", false);
        }

        //die in the void
        if (transform.position.y <= -10)
        {
            transform.position = checkpoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            transform.position = checkpoint;
        }
    }

    public void Floored(bool n_onFloor)
    {
        onFloor = n_onFloor;
    }

    public bool GetFloored()
    {
        return onFloor;
    }

    public void WallBumping(bool n_wallBump)
    {
        wallBumping = n_wallBump;
    }

    public void SetCheckpoint(Vector3 n_checkpoint)
    {
        checkpoint = n_checkpoint;
    }

    public void EndLevel()
    {
        levelended = true;
    }
}
