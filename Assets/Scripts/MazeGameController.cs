using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeGameController : MonoBehaviour
{

    public Button startNetworkButton;

    // Start is called before the first frame update
    void Start()
    {
        startNetworkButton.onClick.Invoke();
    }
}
