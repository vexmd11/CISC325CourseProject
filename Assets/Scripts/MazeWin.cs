using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWin : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("Winner!");
        }
        //this is fucking messy, but it basically gives the game object of the maze to the manager so that it knows that the object won.
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSetup>().weWon(this.GetComponentInParent<mazeController>().gameObject);
    }
}
