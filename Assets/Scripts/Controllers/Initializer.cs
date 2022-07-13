using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    private List<Task> _initializationTasks;

    private void Start()
    {
        _initializationTasks = new List<Task>();
        Initialize();
    }


    private async void Initialize()
    {
        _initializationTasks.Add(LocalizationHandler.Instance.InitLocales().Task);
        _initializationTasks.Add(Addressables.InitializeAsync().Task);

        await Task.WhenAll(_initializationTasks);

        LevelLoader.Instance.LoadLevel(LevelLoader.Instance._menuSceneReference);
    }
}
