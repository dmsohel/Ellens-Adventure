﻿using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(Level);
    }
}
