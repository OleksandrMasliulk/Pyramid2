using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Threading.Tasks;

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

    //Game settings
    [SerializeField] private Dropdown _languageDropdown;

    [SerializeField] private Button _applyButton;
    [SerializeField] private Button _revertButton;
    private bool _isDirty;

    [SerializeField] private SerializableResolution[] _resolutions;
    [SerializeField] private string[] _qualityLevels;
    [SerializeField] private string[] _windowModeOptions; 
    [SerializeField] private AudioMixer _mixer;
    private Settings _settings;

    private void Awake()
    {
        InitSettings();
    }

    public void InitSettings()
    {
        _settings = SaveLoad.Load<Settings>(SaveLoad.settingsProfilePath);
        if (_settings == null)
        {
            _settings = new Settings();
            SaveLoad.Save<Settings>(_settings, SaveLoad.settingsProfilePath);
        }

        //Language
        _languageDropdown.value = _settings.Language;

        //Resolution options setup
        _resolutionDropdown.ClearOptions();
        List<string> resOptions = new List<string>(); 
        for (int i = 0; i < _resolutions.Length; i++)
        {
            resOptions.Add(_resolutions[i].width + "x" + _resolutions[i].height);
        }
        _resolutionDropdown.AddOptions(resOptions);
        _resolutionDropdown.value = FindResIndex(_settings.Resolution);

        //Audio
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, _settings.MasterVolume, true);
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, _settings.SoundVolume, true);
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, _settings.MusicVolume, true);

        LocalizeSettingsDropdowns();
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

        LocalizationHandler.Instance.SetLocale(_settings.Language);

        SetDirty(false);
        SaveLoad.Save<Settings>(_settings, SaveLoad.settingsProfilePath);

        LocalizeSettingsDropdowns();
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

        //Graphics
        _resolutionDropdown.value = FindResIndex(backup.Resolution);
        _qualityDropdown.value = backup.GraphicsQuality;
        _windowDropdown.value = (int)backup.Mode - 1;

        //Audio
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, backup.MasterVolume, true);
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, backup.SoundVolume, true);
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, backup.MusicVolume, true);

        //Game
        _languageDropdown.value = backup.Language;

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
        SetSliderParameters(_masterVolumeSlider, _masterVolumeText, value, true);
        _settings.MasterVolume = value;
        SetDirty(true);
    }

    public void SetSoundVolume(float value)
    {
        SetSliderParameters(_soundVolumeSlider, _soundVolumeText, value, true);
        _settings.SoundVolume = value;
        SetDirty(true);
    }
    
    public void SetMusicVolume(float value)
    {
        SetSliderParameters(_musicVolumeSlider, _musicVolumeText, value, true);
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

    public void SetLanguage()
    {
        _settings.Language = _languageDropdown.value;
        SetDirty(true);
    }

    private void SetSliderParameters(Slider slider, Text text, float value, bool maxIsMin)
    {
        slider.value = value;

        float diff = maxIsMin ? -slider.maxValue : slider.minValue;
        float textValue = Mathf.Lerp(0, 100, 1 - (Mathf.Abs(value + diff) / Mathf.Abs(maxIsMin ? slider.minValue + diff : slider.maxValue)));
        text.text = ((int)textValue).ToString();
    }

    public void LoadSettings()
    {
        Settings settings = SaveLoad.Load<Settings>(SaveLoad.settingsProfilePath);
        if (settings == null)
        {
            settings = new Settings();
        }

        Screen.fullScreenMode = settings.Mode;
        Screen.SetResolution(settings.Resolution.width, settings.Resolution.height, settings.Mode);
        QualitySettings.SetQualityLevel(settings.GraphicsQuality);

        _mixer.SetFloat("MasterVolume", settings.MasterVolume);
        _mixer.SetFloat("SoundVolume", settings.SoundVolume);
        _mixer.SetFloat("MusicVolume", settings.MusicVolume);

        LocalizationHandler.Instance.SetLocale(settings.Language);
    }

    public async void LocalizeSettingsDropdowns()
    {
        List<Task> dropdownsLocalizationTasks = new List<Task>();

        List<string> newQualityOptions = new List<string>();
        _qualityDropdown.ClearOptions();
        for (int i = 0; i < _qualityLevels.Length; i++)
        {
            var op = LocalizationHandler.Instance.GetLocalizedTextAsync(LocalizationHandler.Tables.SETTINGS, _qualityLevels[i]);
            op.Completed += (op) => newQualityOptions.Add(op.Result);
            dropdownsLocalizationTasks.Add(op.Task);
            //_qualityDropdown.options[i].text = LocalizationHandler.Instance.GetTextLocalized(LocalizationHandler.Tables.SETTINGS, _qualityLevels[i]);
        }
        
        List<string> newWindowOptions = new List<string>();
        _windowDropdown.ClearOptions();
        for (int i = 0; i < _windowModeOptions.Length; i++)
        {
            var op = LocalizationHandler.Instance.GetLocalizedTextAsync(LocalizationHandler.Tables.SETTINGS, _windowModeOptions[i]);
            op.Completed += (op) => newWindowOptions.Add(op.Result);
            dropdownsLocalizationTasks.Add(op.Task);
            //_windowDropdown.options[i].text = LocalizationHandler.Instance.GetTextLocalized(LocalizationHandler.Tables.SETTINGS, _windowModeOptions[i]);
        }

        await Task.WhenAll(dropdownsLocalizationTasks);
        _qualityDropdown.AddOptions(newQualityOptions);
        _qualityDropdown.value = _settings.GraphicsQuality;
        _windowDropdown.AddOptions(newWindowOptions);
        _windowDropdown.value = (int)_settings.Mode - 1;
    }
}
