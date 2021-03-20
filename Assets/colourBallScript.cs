using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool red;
    GameObject manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("spawner");
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
