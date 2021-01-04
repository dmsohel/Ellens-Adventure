using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonPlay;
    public GameObject levelSelector;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayLevel1);
    }
    void PlayLevel1()
    {
        levelSelector.SetActive(true);
    }
}
