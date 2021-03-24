using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class managerSetup : MonoBehaviour
{
    public NetworkManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<NetworkManager>();
        manager.networkAddress = NetworkManager.singleton.networkAddress;
        Debug.Log(NetworkManager.singleton.networkAddress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endServer(){
        manager.StopClient();
        manager.StopServer();
    }

}
