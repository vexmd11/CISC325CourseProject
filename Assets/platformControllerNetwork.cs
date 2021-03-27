using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class platformControllerNetwork : NetworkBehaviour
{
    Gyroscope m_Gyro;
    public float speed = 10.0f;
    public bool move;
    public bool gyroAcceleration;
    public bool rotate;
    public Vector3 gyroOffset; 
    Vector3 rotation;

    bool initialized = true;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        Screen.orientation = ScreenOrientation.Portrait;
        rotation.x = 0;//m_Gyro.attitude.eulerAngles.x;
        rotation.z = 0;//m_Gyro.attitude.eulerAngles.y;
        //newPosition = GameObject.Find("gameManager").GetComponent<controlGameView>().increasePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer) {
            if (initialized){
                //Set up and enable the gyroscope (check your device has one)
                m_Gyro = Input.gyro;
                m_Gyro.enabled = true;
                Screen.orientation = ScreenOrientation.Portrait;
                rotation.x = 0;//m_Gyro.attitude.eulerAngles.x;
                rotation.z = 0;//m_Gyro.attitude.eulerAngles.y;
                initialized = false;
                //newPosition = GameObject.Find("gameManager").GetComponent<controlGameView>().increasePlayers();

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
                //transform.eulerAngles = m_Gyro.attitude.eulerAngles + gyroOffset;

                rotation.z -= m_Gyro.rotationRateUnbiased.x * Mathf.Rad2Deg * Time.deltaTime;
                //rotation.z -= m_Gyro.rotationRateUnbiased.y * Mathf.Rad2Deg * Time.deltaTime;

                //rotation.x = m_Gyro.attitude.eulerAngles.x % 360f;
                //rotation.z = m_Gyro.attitude.eulerAngles.y % 360f;   
            
                rotation.y = 0;

            if (Input.anyKeyDown){
                resetRotation();
            }
            
            //transform.eulerAngles = rotation + gyroOffset;
            transform.rotation = Quaternion.Euler(rotation);


            //Debug.Log(m_Gyro.attitude.eulerAngles.x + ",  " + m_Gyro.attitude.eulerAngles.y + ",  " + m_Gyro.attitude.eulerAngles.z);
            //Debug.Log(transform.eulerAngles);
            //Debug.Log(Input.gyro.userAcceleration.x+ ",  " + Input.gyro.userAcceleration.y+ ",  " + Input.gyro.userAcceleration.z );
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

    public void resetRotation() {
        rotation.x = 0;//m_Gyro.attitude.eulerAngles.x;
        rotation.z = 0;//m_Gyro.attitude.eulerAngles.y;

    }

}

    

    //Vector2 values;
    //values.x = m_Gyro.attitude.x;
    //values.y = m_Gyro.attitude.y;

    //rotation.x = m_Gyro.attitude.eulerAngles.x % 360f;
    //rotation.z = m_Gyro.attitude.eulerAngles.y % 360f;            
    //rotation.x = values.x;
    //rotation.z = values.y;
    //rotation.x += Input.gyro.userAcceleration.x;
    //rotation.z += Input.gyro.userAcceleration.y;
    //rotation.y = m_Gyro.attitude.eulerAngles.z % 360f;