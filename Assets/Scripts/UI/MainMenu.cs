using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SettingsWindow _settings;

    private IEnumerator InitializationChain() {
        Debug.LogWarning("Main menu init");
        GetComponent<UIPanel>().EnablePanel();
        _settings.LoadSettings();
        yield return null;
    }

    private void Start() => StartCoroutine(InitializationChain());

    public void StartGame(MapSO so) => LevelLoader.Instance.LoadLevel(so.SceneReference);

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
