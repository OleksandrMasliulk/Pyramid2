using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }

    [SerializeField] private GameObject _loadingScreen;

    public AssetReference _menuSceneReference;
    private AssetReference _currentSceneReference;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public async void LoadLevel(AssetReference level)
    {
        //List<Task> loadTasks = new List<Task>();

        _loadingScreen.SetActive(true);

        if (_currentSceneReference != null)
            await UnloadScene(_currentSceneReference); 
        await LoadScene(level);

        _loadingScreen.SetActive(false);

        Debug.LogWarning("Scene loaded successfully");
    }

    private async Task LoadScene(AssetReference reference)
    {
        var op = reference.LoadSceneAsync();
        op.Completed += (op) => 
        {
            _currentSceneReference = reference;
        };

        await op.Task;
    }

    private async Task UnloadScene(AssetReference reference)
    {
        var op = reference.UnLoadScene();
        op.Completed += (scene) =>
        {
            reference.ReleaseAsset();
        };

        await op.Task;
    }

    public void ReloadLevel()
    {
        LoadLevel(_currentSceneReference);
    }

    public void MainMenu()
    {
        LoadLevel(_menuSceneReference);
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    switch (level)
    //    {
    //        default:
    //            break;
    //        case 0:
    //            AudioManager.Instance.PlayLevelTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().mainMenuTheme);
    //            break;
    //        case >= 1 and <= 2:
    //            AudioManager.Instance.PlayLevelTheme(AudioManager.Instance.GetSoundBoard<MusicSoundBoard>().pyramidMenuTheme);
    //            break;
    //    }
    //}
}
