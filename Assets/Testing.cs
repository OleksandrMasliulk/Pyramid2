using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Testing : MonoBehaviour
{
    private void Awake()
    {
        Addressables.InitializeAsync();
    }
}
