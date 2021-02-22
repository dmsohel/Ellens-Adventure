using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get {return  instance; } }

    public string level1;
    private void Awake()
    {
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
        if (GetLevelStatus(level1) == LevelStatus.Locked)
        {
            SetLevelStatus(level1, LevelStatus.Unlocked);
        }
    }

    public void MarkLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        Instance.SetLevelStatus(currentscene.name, LevelStatus.Completed);
        int nextsceneIndex = currentscene.buildIndex + 1;
       // Scene nextscene = SceneManager.GetSceneByBuildIndex(nextsceneIndex);
       // Instance.SetLevelStatus(nextscene.name, LevelStatus.Unlocked);
        SceneManager.LoadScene(nextsceneIndex);
        

        //Instance.SetLevelStatus(nextscene.name, LevelStatus.Unlocked);
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
