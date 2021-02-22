using UnityEngine;
public class LevelOverController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null) 
        {
            SoundManager.Instance.Play(Sounds.NextLevel);
            LevelManager.Instance.MarkLevelComplete();
           
        }
    }
}
