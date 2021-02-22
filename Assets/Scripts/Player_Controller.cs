using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;

    public bool isGrounded = false;
    public Animator animator;
    public float speed;
    public float yjump;
    public ScoreController scoreController;

     public  void DeathAnimation()
    {
        animator.SetBool("Dead", true);
        
    }

    void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        
    }


    public void PickUpKey()
    {
        
        scoreController.IncreaseScore(10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Jump");

        RunAnimation(horizontal);
        JumpAnimation(vertical);
        PhysicalMovementJump(vertical);
        PhysicalMovementRun(horizontal);
    }

    void RunAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }

    void JumpAnimation(float vertical)
    {
        if (vertical > 0 && isGrounded == true)
        {
            animator.SetBool("HJump", true);
        }
        else if (vertical <= 0)
            animator.SetBool("HJump", false);
    }

    void PhysicalMovementRun(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void PhysicalMovementJump(float vertical)
    {
        if (vertical > 0 && isGrounded == true)
        {
            Vector3 scale = transform.localScale;

            _rigidbody2d.AddForce(new Vector2(0F, yjump), ForceMode2D.Impulse);

        }


    }


}
       

