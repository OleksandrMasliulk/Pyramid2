using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AddressableAssets;

public class HUBMapManager : MonoBehaviour
{
    [SerializeField] private UIPanel _infoPanel;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _locationText;
    [SerializeField] private TMP_Text _infoText;

    private AssetReference _highlightedMap;

    private AssetReference _selectedMapRef;
    public AssetReference SelectedMap => _selectedMapRef;

    private void OnEnable()
    {
        _nameText.text = "";
        _locationText.text = "";
        _infoText.text = "";
        _highlightedMap = null;
    }

    public void ShowMapInfo(MapSO so)
    {
        _nameText.text = so.Name;
        _locationText.text = so.Lcation;
        _infoText.text = so.Info;
        _highlightedMap = so.SceneReference;
        _infoPanel.EnablePanel();
    }

    public void SelectMap()
    {
        _selectedMapRef = _highlightedMap;
    }
}
