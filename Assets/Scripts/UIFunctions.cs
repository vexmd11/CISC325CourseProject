using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class UIFunctions : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameSelectPanel;
    public GameObject mobileMainMenuPanel;
    public GameObject mobileConnectedPanel;
    public GameObject mobileSettingsPanel;
    public GameObject network;
    public Slider xSens;
    public Slider ySens;
    public Slider zSens;

    public void Start()
    {
        /*
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
        */
    }
    
    public void PressPlay(){
        mainMenuPanel.SetActive(false);
        gameSelectPanel.SetActive(true);
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

    public void GameSelectBack(){
        gameSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void MobileSettingsBack()
    {
        mobileSettingsPanel.SetActive(false);
        mobileMainMenuPanel.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }

    public void LoadGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void MobileResetSettings()
    {
        xSens.value = 0.5f;
        ySens.value = 0.5f;
        zSens.value = 0.5f;
    }
}
