using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlGameView : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("The number of players that are in the game. Right now, it's only between 1 and 2")]
    public int numberOfPlayers = 1;
    bool joined = false;

    Camera player1, player2;

    public Transform spawn1, spawn2;


    // Update is called once per frame

    //only increases number of players when the second player joins
    public Transform increasePlayers(){
        if (!joined) {
            joined = true;
            return spawn1;
        } else {
            numberOfPlayers++;
            return spawn2;
        }
            
        

        
    }
}
