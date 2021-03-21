using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlGameView : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("The number of players that are in the game. Right now, it's only between 1 and 2")]
    public int numberOfPlayers;

    Camera player1, player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfPlayers == 1){
            player1 = GameObject.Find("camera1").GetComponent<Camera>();
            player1.rect = new Rect(0,0,1,1);
        } else if (numberOfPlayers == 2) {
            player1 = GameObject.Find("camera1").GetComponent<Camera>();
            player2 = GameObject.Find("camera2").GetComponent<Camera>();
            player1.rect = new Rect(0,0,1,0.5f);
            player2.rect = new Rect(0,0.5f,1,1);
        }
    }
}
