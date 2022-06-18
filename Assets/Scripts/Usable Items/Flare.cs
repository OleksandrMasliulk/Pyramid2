using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flare : Item
{
    [SerializeField] private GameObject flarePrefab;

    public override void Use(PlayerController user)
    {
        Debug.Log("FLARE USED");
        base.Use(user);

        Throw(user);
    }

    private void Throw(PlayerController user)
    {
        MonoBehaviour.Instantiate(flarePrefab, user.transform.position, Quaternion.identity);
    }

    public override bool OnButtonPressed(PlayerController user)
    {
        Use(user);

        return base.OnButtonPressed(user);
    }

    public override bool OnButtonReleased(PlayerController user)
    {
        return base.OnButtonReleased(user);
    }
}
