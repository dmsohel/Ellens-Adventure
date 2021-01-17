using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public bool IsMute = false;
    public float Volume = 1f;
    public AudioSource soundEffects;
    public AudioSource soundMusic;
    public Button SoundON;
    public Button SoundOFF;

    public SoundType[] Soundsarray;

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
        SoundON.onClick.AddListener(VolumeON);
        SoundOFF.onClick.AddListener(VolumeOFF);
     
        PlayMusic(Sounds.Music);
    

    }
    public void SetVolume(float Volume)
    {
        soundEffects.volume = Volume;
        soundMusic.volume = Volume;
    }

    public void Mute(bool status)
    {
        IsMute = status;
    }

    public void PlayMusic(Sounds sound)
    {
        if (IsMute==true)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
            
        }
        else
        {
            Debug.Log("Sound not found for" + sound);
        }
    }

    public void Play(Sounds sound)
    {
        if (IsMute==true)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffects.PlayOneShot(clip);
        }
        else 
        {
            Debug.Log("Sound not found for"+sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Soundsarray, i => i.soundType == sound);
        if (item != null)
        
            return item.soundClip;
        return null;

    }
    private void VolumeOFF()
    {
        SoundOFF.gameObject.SetActive(false);
        SoundON.gameObject.SetActive(true);
        soundMusic.Stop();
        SoundManager.Instance.Mute(true);
    }

    private void VolumeON()
    {
        SoundOFF.gameObject.SetActive(true);
        SoundON.gameObject.SetActive(false);
        soundMusic.Play();
        SoundManager.Instance.Mute(false);
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;

}
public enum Sounds
{
    ButtonClick,
    Music,
    PickUPKey,
    PlayerDeath,
    NextLevel,
    EnemyDeath,
    PlayerJump,
    Acid
}
