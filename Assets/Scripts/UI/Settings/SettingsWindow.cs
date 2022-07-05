using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsWindow : MonoBehaviour
{
    //Graphics settings
    [SerializeField] private Dropdown _resolutionDropdown;
    [SerializeField] private Dropdown _qualityDropdown;
    [SerializeField] private Dropdown _windowDropdown;

    //Audio settings
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Text _masterVolumeText;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Text _soundVolumeText;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Text _musicVolumeText;

    [SerializeField] private Button _applyButton;
    [SerializeField] private Button _revertButton;
    private bool _isDirty;

    [SerializeField] private SerializableResolution[] _resolutions;
    [SerializeField] private string[] _qualityLevels;
    [SerializeField] private AudioMixer _mixer;
    private Settings _settings;

    public void InitSettings()
    {
        _settings = SaveLoad.Load<Settings>(SaveLoad.settingsProfilePath);
        if (_settings == null)
        {
            _settings = new Settings();
            SaveLoad.Save<Settings>(_settings, SaveLoad.settingsProfilePath);
        }
        
        //Resolution options setup
        _resolutionDropdown.ClearOptions();
        List<string> resOptions = new List<string>(); 
        for (int i = 0; i < _resolutions.Length; i++)
        {
            resOptions.Add(_resolutions[i].width + "x" + _resolutions[i].height);
        }
        _resolutionDropdown.AddOptions(resOptions);
        _resolutionDropdown.value = FindResIndex(_settings.Resolution);

        //Quality options setup
        _qualityDropdown.ClearOptions();
        List<string> qualityOptions = new List<string>();
        for (int i = 0; i < _qualityLevels.Length; i++)
        {
            qualityOptions.Add(_qualityLevels[i]);
            
        }
        _qualityDropdown.AddOptions(qualityOptions);
        _qualityDropdown.value = _settings.GraphicsQuality;
        _windowDropdown.value = (int)_settings.Mode - 1;

        //Audio
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, _settings.MasterVolume);
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, _settings.SoundVolume);
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, _settings.MusicVolume);

        ApplySettings();

        SetDirty(false);
    }

    public void ApplySettings()
    {
        Screen.fullScreenMode = _settings.Mode;
        Screen.SetResolution(_settings.Resolution.width, _settings.Resolution.height, _settings.Mode);
        QualitySettings.SetQualityLevel(_settings.GraphicsQuality);

        _mixer.SetFloat("MasterVolume", _settings.MasterVolume);
        _mixer.SetFloat("SoundVolume", _settings.SoundVolume);
        _mixer.SetFloat("MusicVolume", _settings.MusicVolume);

        SetDirty(false);
        SaveLoad.Save<Settings>(_settings, SaveLoad.settingsProfilePath);
    }

    private int FindResIndex(SerializableResolution res)
    {
        int index = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].height == res.height && _resolutions[i].width == res.width)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public void RevertSettings()
    {
        Settings backup = SaveLoad.Load<Settings>(SaveLoad.settingsProfilePath);

        _resolutionDropdown.value = FindResIndex(backup.Resolution);
        _qualityDropdown.value = backup.GraphicsQuality;
        _windowDropdown.value = (int)backup.Mode - 1;

        //Audio
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, backup.MasterVolume);
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, backup.SoundVolume);
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, backup.MusicVolume);

        _settings = backup;
        SetDirty(false);
    }

    private void SetDirty(bool value)
    {
        if (_isDirty == value)
            return;

        _isDirty = value;
        _applyButton.interactable = value;
        _revertButton.interactable = value;
    }

    public void SetMasterVolume(float value)
    {
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, value);
        _settings.MasterVolume = value;
        SetDirty(true);
    }

    public void SetSoundVolume(float value)
    {
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, value);
        _settings.SoundVolume = value;
        SetDirty(true);
    }
    
    public void SetMusicVolume(float value)
    {
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, value);
        _settings.MusicVolume = value;
        SetDirty(true);
    }

    public void SetResolution()
    {
        _settings.Resolution = _resolutions[_resolutionDropdown.value];
        SetDirty(true);
    }

    public void SetQuality()
    {
        _settings.GraphicsQuality = _qualityDropdown.value;
        SetDirty(true);
    }

    public void SetWindowMode()
    {
        _settings.Mode = (FullScreenMode)(_windowDropdown.value + 1);
        SetDirty(true);
    }

    private void SetSliderParameters(Slider slider, Text text, float value)
    {
        slider.value = value;
        float textValue = Mathf.Lerp(0, 100, 1 - (Mathf.Abs(value) / 80));
        text.text = ((int)textValue).ToString();
    }
}
