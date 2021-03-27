using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class managerSetup : MonoBehaviour
{
    public NetworkManager manager;
    public GameObject currentScenePrefab;

    // Start is called before the first frame update

    void Awake(){

    }

    void Start()
    {
        manager = this.GetComponent<NetworkManager>();
        manager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManager>();
        manager.networkAddress = NetworkManager.singleton.networkAddress;
        manager.GetComponent<NetworkManager>().spawnPrefabs[0] = currentScenePrefab;
        manager.playerPrefab = currentScenePrefab;
        Debug.Log(NetworkManager.singleton.networkAddress);
    }

    public void endServer(){
        manager.StopClient();
        manager.StopServer();
    }

}
