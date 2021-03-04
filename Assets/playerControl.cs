using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : NetworkBehaviour
{
    Gyroscope gyro;

     public float speed = 10.0f;

    public bool gyroAcceleration;
    public bool rotate;

    bool instantiated = true;

    //sadly, right now this DOESNT RUN!
    void start() {

        gyro = Input.gyro;
        gyro.enabled = true;
            
    }

    void HandleMovement(){


        if (isLocalPlayer){
                if (instantiated){
                    gyro = Input.gyro;
                    gyro.enabled = true;
                    instantiated = false; //needs to be here since the network doesn't actually run a start() method when instantiating a player.

                }

            Vector3 dir = Vector3.zero;

            //switches between two versions of acceleration. One uses the gyroscope within the phone, the other uses the accelerometer. 
            /*
                The gyro acceleration doesn't recognize tilting the phone as acceleration, while the other version does. These two are useful for different purposes.
            */
            if (gyroAcceleration) {
                dir.x = -Input.gyro.userAcceleration.y;
                dir.z = Input.gyro.userAcceleration.x;
            }
            else{
                dir.x = -Input.acceleration.y;
                dir.z = Input.acceleration.x;
            }
        
            if (rotate) {
                transform.rotation = gyro.attitude;
            }

            if (dir.sqrMagnitude > 1)
                dir.Normalize();
            if (dir.sqrMagnitude < 0.1)
                dir = Vector3.zero;

            dir *= Time.deltaTime;

            //transform.Translate(dir*speed);

            
        }
    }

    void Update(){
        HandleMovement();
    }
}
