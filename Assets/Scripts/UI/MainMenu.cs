using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SettingsWindow _settings;

    private IEnumerator InitializationChain()
    {
        yield return null;

        _settings.LoadSettings();
    }

    private void Start()
    {
        StartCoroutine(InitializationChain());
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
