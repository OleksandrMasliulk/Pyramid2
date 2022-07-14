using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }

    [SerializeField] private GameObject _loadingScreen;

    public AssetReference _menuSceneReference;
    public AssetReference _tutorialSceneReference;
    public AssetReference _pyramid1SceneReference;

    private AssetReference _currentSceneReference;

    public int CurrentLevel => SceneManager.GetActiveScene().buildIndex;

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

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public async void LoadLevel(AssetReference level)
    {
        //List<Task> loadTasks = new List<Task>();

        //SHOW LOADING SCREEN
        _loadingScreen.SetActive(true);

        //Unload current scene
        if (_currentSceneReference != null)
        {
            await UnloadScene(_currentSceneReference);
        }
        //Load new scene and set it as current
        await LoadScene(level);

        //HIDE LOADING SCREEN
        _loadingScreen.SetActive(false);

        Debug.LogWarning("Scene loaded successfully");
    }

    private async Task LoadScene(AssetReference reference)
    {
        var op = reference.LoadSceneAsync(LoadSceneMode.Single, true);
        op.Completed += (scene) =>
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
            _currentSceneReference = null;
        };

        await op.Task;
    }

    public void ReloadLevel()
    {
        LoadLevel(CurrentLevel);
    }

    public void MainMenu()
    {
        LoadLevel(_menuSceneReference);
    }

    public void LoadHUB()
    {
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
