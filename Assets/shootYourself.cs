using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class shootYourself : NetworkBehaviour
{

    public float force;
    public GameObject cannonHead;

    // Start is called before the first frame update
    void Start()
    {
        cannonHead = GameObject.FindGameObjectWithTag("Tip");
        GetComponent<Rigidbody>().AddForce((cannonHead.transform.forward + (cannonHead.transform.up)*0.1f) * force);
    }
}
