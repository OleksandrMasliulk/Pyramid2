using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class HUB : MonoBehaviour
{
    private AssetReference chosenMap;

    private void Start()
    {
        chosenMap = LevelLoader.Instance._tutorialSceneReference;
    }

    public void StartGame()
    {
        LevelLoader.Instance.LoadLevel(chosenMap);
    }

    public void ChoseMap(AssetReference reference)
    {
        chosenMap = reference;
    }
}
