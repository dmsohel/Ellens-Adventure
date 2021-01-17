using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Speed;
    public float horizontal;
    private void Update()
        
    {
        EnemyMovementRun();
        RunAnimation(horizontal);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();

            player_Controller.Lose_Health();
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
      {

          if (collision.gameObject.CompareTag("SideWayTrigger"))
          {

              horizontal = -horizontal;
             // RunAnimation(horizontal);
          }
      }

    private void EnemyMovementRun()
    {
        Vector3 position = transform.position;
        position.x +=horizontal*Speed * Time.deltaTime;
        transform.position = position;
    }
    public void RunAnimation(float horizontal)
    {
       

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
}
