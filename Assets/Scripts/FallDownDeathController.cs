using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDownDeathController : MonoBehaviour
{
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();
            player_Controller.DeathAnimation();
           
        }

    }
}
