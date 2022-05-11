using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private RemoteInterractComponent[] objectsToInterract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        foreach (RemoteInterractComponent obj in objectsToInterract)
            obj.Interract(player);
    }
}
