using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;
public class GameSetup : MonoBehaviour
{
    // Start is called before the first frame update

    int playerCount = 0;
    bool gameEnded = false;
    GameObject player1, player2;
    public Text display;
    string text = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = text;
    }

    //assigns player 1 or player 2 to an incoming player.
    public void addPlayer(GameObject player){
        if (playerCount == 0) {
            player1 = player;
            
        } else if (playerCount == 1) {
            player2 = player;
            
        }
        playerCount++;
    }

    //comparing the object that won with player 1 and player 2. 
    public void weWon(GameObject player) {
        if (!gameEnded) {
            if (player.Equals(player1)){ 
            text = "PLAYER 1 WINS!";
        } else {
            text = "PLAYER 2 WINS!";
        }
        gameEnded = true;
        StartCoroutine(endGame(5));
        }
        
    }

    IEnumerator endGame(int time) {
        yield return new WaitForSeconds(time);

        GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManager>().StopServer();
        SceneManager.LoadScene(0);
    }
}
