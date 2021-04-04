using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endBinGame : MonoBehaviour
{
    // Start is called before the first frame update
    spawnerScript spawner;
    void Start()
    {
        spawner = this.GetComponent<spawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.score >=25){


            StartCoroutine(endGame(3));
        }
    }

    IEnumerator endGame(int time) {
        

        GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<managerSetup>().endServer();
        
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(0);
    }
}
