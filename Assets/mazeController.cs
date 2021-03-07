using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeController : NetworkBehaviour
{
    Gyroscope m_Gyro;
    public float speed = 10.0f;

    public bool move;
    public bool gyroAcceleration;
    public bool rotate;
    public Vector3 gyroOffset; 
    Vector3 rotation;

    bool instantiated = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        //switches between two versions of acceleration. One uses the gyroscope within the phone, the other uses the accelerometer. 
        /*
            The gyro acceleration doesn't recognize tilting the phone as acceleration, while the other version does. These two are useful for different purposes.
        
        */
        
        if (isLocalPlayer) {
            if (instantiated) {
                //Set up and enable the gyroscope (check your device has one)
                m_Gyro = Input.gyro;
                m_Gyro.enabled = true;
                instantiated = false;
            }
        }

        handleMovement();

    }

    void handleMovement() {

        Vector3 dir = Vector3.zero;

        if (gyroAcceleration) {
            dir.x = -Input.gyro.userAcceleration.y;
            dir.z = Input.gyro.userAcceleration.x;
        }
        else{
            dir.x = -Input.acceleration.y;
            dir.z = Input.acceleration.x;
        }
        
        if (rotate) {
            //transform.eulerAngles = m_Gyro.attitude.eulerAngles + gyroOffset;

            rotation.x = m_Gyro.attitude.eulerAngles.x;
            rotation.z = m_Gyro.attitude.eulerAngles.y;
            //rotation.y = -m_Gyro.attitude.eulerAngles.z;
            transform.eulerAngles = rotation + gyroOffset;
            Debug.Log(m_Gyro.attitude.eulerAngles.x + ",  " + m_Gyro.attitude.eulerAngles.y + ",  " + m_Gyro.attitude.eulerAngles.z);
        }

        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        if (dir.sqrMagnitude < 0.1)
            dir = Vector3.zero;

            dir *= Time.deltaTime;

        if (move)
            transform.Translate(dir*speed);
    }
}
