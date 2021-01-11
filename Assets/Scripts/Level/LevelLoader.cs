using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string Level;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(Level);
        switch(levelstatus)
            {

            case LevelStatus.Locked:
            Debug.Log("Locked level can't access");
            break;

            case LevelStatus.Unlocked:
                Debug.Log("Level is Unlocked");
                SceneManager.LoadScene(Level);
                break;

            case LevelStatus.Completed:
                Debug.Log("Level is Completed");
                SceneManager.LoadScene(Level);
                break;
        }

        
    }
}
