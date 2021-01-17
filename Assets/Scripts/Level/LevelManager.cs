using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get {return  instance; } }

    public string level1,MainMenu;
    private void Awake()
    {
      //PlayerPrefs.DeleteAll();
        if (instance == null)
        {
            instance = this;// it refers to the class LevelManager (using this we can call gameobject also this.gameobj)
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
      
    }

    private void Start()
    {
        if (GetLevelStatus(level1) == LevelStatus.Locked || GetLevelStatus(MainMenu) == LevelStatus.Locked)
        {
            SetLevelStatus(MainMenu, LevelStatus.Unlocked);
            SetLevelStatus(level1, LevelStatus.Unlocked);
        }
    }

    public void MarkLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        Instance.SetLevelStatus(currentscene.name, LevelStatus.Completed);
        int nextsceneIndex = currentscene.buildIndex + 1;
        if (nextsceneIndex < 5)
        {
            SceneManager.LoadSceneAsync(nextsceneIndex);
            // SceneManager.LoadScene(nextsceneIndex);
            Scene nextscene = SceneManager.GetSceneByBuildIndex(nextsceneIndex);
            Instance.SetLevelStatus(nextscene.name, LevelStatus.Unlocked);
        }
      
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level);
        return levelstatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelstatus)
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
    }

  
}
