using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;

    public bool isGrounded = false;
    public Animator animator;
    public float speed;
    public float yjump;
    public bool isDead;
  



    void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("DeadPlatform")) 
            {
                isDead = true;
           
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Level2"))
        {
            SceneManager.LoadScene(1);
         
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
        DeadAnimation(isDead);
       

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

    void DeadAnimation(bool isDead)
    {
        if (isDead == true)
        {
            animator.SetBool("Dead", true);
            SceneManager.LoadScene(0);
           
        }
        

       
     



    }
}
       

