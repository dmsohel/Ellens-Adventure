﻿using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonPlay;
    public GameObject levelSelector;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(showlevelselector);
    }
    void showlevelselector()
    {
        
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelSelector.SetActive(true);
    }
}
