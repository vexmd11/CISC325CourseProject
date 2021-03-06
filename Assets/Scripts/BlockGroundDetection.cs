using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockGroundDetection : MonoBehaviour
{
    public BoxCollider ground;
    public BlockGameController controllerObject;
    Boolean hitFlag = false;
    void Start()
    {
        controllerObject.numBlocks++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            BoxCollider otherCollider = collision.gameObject.GetComponent<BoxCollider>();

            if (otherCollider.Equals(ground) && !hitFlag) {

                hitFlag = true;
                controllerObject.numBlocks--;
                Destroy(this.gameObject);
            }
        }
        catch (Exception e) {
            Debug.Log(e);
        }

    }
}
