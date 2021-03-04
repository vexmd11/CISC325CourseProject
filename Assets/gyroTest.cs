using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroTest : MonoBehaviour
{
    Gyroscope m_Gyro;
    public float speed = 10.0f;

    public bool gyroAcceleration;
    public bool rotate;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.rotation = m_Gyro.attitude;
        }

        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        if (dir.sqrMagnitude < 0.1)
            dir = Vector3.zero;

            dir *= Time.deltaTime;

            //transform.Translate(dir*speed);

    }
}
