using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractComponent : MonoBehaviour
{
    public void Interract(CharacterBase user)
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
