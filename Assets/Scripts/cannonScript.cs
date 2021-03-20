using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform ballTrans;
    public GameObject ball;
    public GameObject cannonHead;
    public Vector3 offset;
    void Start()
    {
        ballTrans = ball.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                Instantiate(ballTrans, cannonHead.transform.position , Quaternion.identity);
                //ballTrans.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            }
                
        }
    }
}
