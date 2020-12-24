using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float yjump, xjump;
    Rigidbody2D _rigidbody2d;
   
    // Start is called before the first frame update
    void Start()
     {
        
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
     }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
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
        if (vertical > 0)
        {
            animator.SetBool("HJump", true);
        }
        else
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
        if (vertical > 0)
        {
            Vector3 scale = transform.localScale;
            if (scale.x >= 0)
            {

                _rigidbody2d.AddForce(new Vector2(xjump, yjump), ForceMode2D.Impulse);
            }
              else

               _rigidbody2d.AddForce(new Vector2(-xjump, yjump), ForceMode2D.Impulse);
        }
    }
}

   
       

