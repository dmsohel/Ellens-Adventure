
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
    public GameOverController gameOverController;
    public GameObject Health1, Health2, Health3;
    public int health = 3;
    
   
  
    public  void DeathAnimation()
    {
      animator.SetBool("Dead", true);
       
    }
   
    public void Gamecompletefunction()
    {
        Health3.gameObject.SetActive(false);
        Health2.gameObject.SetActive(false);
        Health1.gameObject.SetActive(false);
        this.enabled = false;
        gameOverController.PlayerDead();
    }
     public void Lose_Health()
    {
        
      //  Debug.Log(health);
        switch (health)
        {
            case 3:
                Health3.gameObject.SetActive(false);
                Health2.gameObject.SetActive(true);
                Health1.gameObject.SetActive(true);
                health--;
                break;
            case 2:
                Health3.gameObject.SetActive(false);
                Health2.gameObject.SetActive(false);
                Health1.gameObject.SetActive(true);
                health--;
                break;
            case 1:
                Health3.gameObject.SetActive(false);
                Health2.gameObject.SetActive(false);
                Health1.gameObject.SetActive(false);
             //   health--;
                DeathAnimation();
                break;



        }
       
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
        PhysicalMovementJump(vertical);
        JumpAnimation(vertical);
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
       if (vertical > 0 && _rigidbody2d.velocity.y > 0)
        {
            animator.SetBool("PlayerUP", true);
            animator.SetBool("PlayerDOWN", false);
        }
        else 
        {
            animator.SetBool("PlayerUP", false);
            animator.SetBool("PlayerDOWN", true);
        }
        if (_rigidbody2d.velocity.y == 0)
        {
            animator.SetBool("PlayerDOWN", false);     
        }

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
      
            _rigidbody2d.AddForce(new Vector2(0F, yjump), ForceMode2D.Impulse);
          isGrounded = false;

        }

    }


}
       

