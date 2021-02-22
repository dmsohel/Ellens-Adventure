using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonPlay;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayLevel1);
    }
    void PlayLevel1()
    {
        SceneManager.LoadScene(0);
    }
}
