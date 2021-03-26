using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool start;
    public GameObject rball, gball;

    [Tooltip("canvas textbox that will display this score")]
    public Text scoreDisplay;

    [Tooltip("Player this spawner/score counter associated with. 1-4")]
    public int playerNumber;
    bool spawn = true;

    public int score;

    [Tooltip("Speed that balls spawn (in seconds).")]
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start){
            if (spawn) //prevents a shit ton of balls from spawning
                StartCoroutine(spawnBalls());    
        }
        //Debug.Log("SCORE IS:" + score);
        scoreDisplay.text = "SCORE: " + score;

    }

    IEnumerator spawnBalls(){

        spawn = false;
        GameObject ball;

        if (Random.Range(0f,1f) < 0.5f){
            ball = rball;
        } else {
            ball = gball;
        }

        ball.GetComponent<colourBallScript>().playerNumber = playerNumber;

        //spawn ball
        Instantiate(ball, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(speed);
        spawn = true; //allow next ball to spawn

    }

    public void startGame() {
        start = true;
    }
}
