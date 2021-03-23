using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeterminePlatform : MonoBehaviour
{

    public GameObject connectedPanel;
    public GameObject tutorialPanel1;
    public Button startGameButton;
    public Button joinGameButton;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Debug.Log("handheld");
            connectedPanel.SetActive(true);
            tutorialPanel1.SetActive(false);
            joinGameButton.onClick.Invoke();
        }
        else
        {
            Debug.Log("PC");
            tutorialPanel1.SetActive(true);
            connectedPanel.SetActive(false);
            startGameButton.onClick.Invoke();
        }
    }
}
