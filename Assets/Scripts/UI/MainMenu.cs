using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SettingsWindow _settings;

    private void Start()
    {
        _settings.LoadSettings();
        //AudioManager.PlaySound(AudioManager.Sound.LevelTheme, true);
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
