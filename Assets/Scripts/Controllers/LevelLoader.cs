using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader Instance { get; private set; }
    public AssetReference _menuSceneReference;

    [SerializeField] private GameObject _loadingScreen;
    private AssetReference _currentSceneReference;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public async void LoadLevel(AssetReference level) {
        _loadingScreen.SetActive(true);

        if (_currentSceneReference != null)
            await UnloadScene(_currentSceneReference); 
        await LoadScene(level);

        _loadingScreen.SetActive(false);
        Debug.LogWarning("Scene loaded successfully");
    }

    private async Task LoadScene(AssetReference reference) {
        var op = reference.LoadSceneAsync();
        op.Completed += (op) =>  {
            _currentSceneReference = reference;
        };
        await op.Task;
    }

    private async Task UnloadScene(AssetReference reference) {
        var op = reference.UnLoadScene();
        op.Completed += (scene) => {
            reference.ReleaseAsset();
        };
        await op.Task;
    }

    public void ReloadLevel() => LoadLevel(_currentSceneReference);

    public void MainMenu() => LoadLevel(_menuSceneReference);
}
