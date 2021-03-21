using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool red;
    GameObject manager;
    public int playerNumber;
    void Start()
    {
        if (playerNumber == 1)
            manager = GameObject.FindGameObjectWithTag("spawner");
        else
            manager = GameObject.FindGameObjectWithTag("spawner2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col) {
        if (red){
            if (col.gameObject.tag == "redGoal"){
                manager.GetComponent<spawnerScript>().score++;
            }
        } else {
            if (col.gameObject.tag == "greenGoal"){
                manager.GetComponent<spawnerScript>().score++;
            }
        }
        Debug.Log("here");
        Destroy(this.gameObject);
    } 
    
}
