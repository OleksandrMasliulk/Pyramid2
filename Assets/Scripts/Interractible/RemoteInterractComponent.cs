using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteInterractComponent : MonoBehaviour
{
    public void Interract(PlayerController user)
    {
        IInterractible objToInterract = GetComponent<IInterractible>();
        if (objToInterract == null)
        {
            Debug.LogWarning("Nothing to interract with on this Game Object");
            return;
        }

        objToInterract.Interract(user);
    }
}
