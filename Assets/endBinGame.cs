using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class endBinGame : MonoBehaviour
{
    // Start is called before the first frame update
    spawnerScript spawner;
    public Text victory;
    string text = "";
    void Start()
    {
        spawner = this.GetComponent<spawnerScript>();
        victory.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawner.score >=25){

            victory.text = "You Win!";
            StartCoroutine(endGame(3));
        }
    }

    IEnumerator endGame(int time) {

        GameObject.FindGameObjectWithTag("Player").GetComponent<platformControllerNetwork>().goBack();
        yield return new WaitForSeconds(time);

        GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<managerSetup>().endServer();

        SceneManager.LoadScene(0);
    }
}
