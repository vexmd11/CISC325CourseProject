using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSpawners : MonoBehaviour
{
    

    public void initiateSpawners(){
        GameObject.FindGameObjectWithTag("spawner").GetComponent<spawnerScript>().startGame();
    }
}
