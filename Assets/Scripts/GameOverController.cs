﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
    }
    public void PlayerDead()
    {
        gameObject.SetActive(true);
    }
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}


