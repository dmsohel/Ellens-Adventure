
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMainMenu;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
        buttonMainMenu.onClick.AddListener(TaketoMainMenu);
    }
    public void PlayerDead()
    {
        gameObject.SetActive(true);
    }

    public void TaketoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}


