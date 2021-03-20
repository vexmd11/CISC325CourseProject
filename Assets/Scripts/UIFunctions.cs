using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Mirror;

public class UIFunctions : MonoBehaviour
{
    //Game audio
    public AudioSource source;
    public AudioSource buttonSource;
    public AudioClip menuSelect;
    public AudioClip menuBack;

    //PC related UI
    public GameObject mainMenuPanel;
    public GameObject gameSelectPanel;
    public GameObject settingsPanel;

    //Mobile related UI
    public GameObject mobileMainMenuPanel;
    public GameObject mobileConnectedPanel;
    public GameObject mobileSettingsPanel;
    public Slider xSens;
    public Slider ySens;
    public Slider zSens;

    //Network reference?
    public GameObject network;
    

    public void Start()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            Debug.Log("handheld");
            mobileMainMenuPanel.SetActive(true);
        }
        else
        {
            Debug.Log("PC");
            mainMenuPanel.SetActive(true);
        }
    }
    
    public void PressPlay(){
        mainMenuPanel.SetActive(false);
        gameSelectPanel.SetActive(true);
        buttonSource.PlayOneShot(menuSelect);
    }

    public void MobilePressPlay()
    {
        mobileMainMenuPanel.SetActive(false);
        mobileConnectedPanel.SetActive(true);
    }

    public void MobileLeaveGame()
    {
        
    }

    public void MobilePressSettings()
    {
        mobileMainMenuPanel.SetActive(false);
        mobileSettingsPanel.SetActive(true);
    }

    public void PressSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        buttonSource.PlayOneShot(menuSelect);
    }

    public void SettingsBack()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        buttonSource.PlayOneShot(menuBack);
    }

    public void GameSelectBack(){
        gameSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        buttonSource.PlayOneShot(menuBack);
    }

    public void MobileSettingsBack()
    {
        mobileSettingsPanel.SetActive(false);
        mobileMainMenuPanel.SetActive(true);
    }

    public void Quit(){
        buttonSource.PlayOneShot(menuSelect);
        Application.Quit();
    }

    public void LoadGame(int sceneNumber)
    {
        buttonSource.PlayOneShot(menuSelect);
        SceneManager.LoadScene(sceneNumber);
    }

    public void MobileResetSettings()
    {
        xSens.value = 0.5f;
        ySens.value = 0.5f;
        zSens.value = 0.5f;
    }

    public void SetMusicVolume(float volume)
    {
        source.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        buttonSource.volume = volume;
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
