using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroyOnDisconnect : NetworkBehaviour
{
    public virtual void OnClientDisconnect(NetworkConnection conn)
    {
        Destroy(gameObject);
    }
}
