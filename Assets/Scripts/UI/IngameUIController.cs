using UnityEngine;
using System;

public class IngameUIController : MonoBehaviour {
    public static event Action OnResurrectClick;

    [SerializeField] private UIPanel _loseScreen;
    [SerializeField] private UIPanel _winScreen;
    [SerializeField] private UIPanel _menu;

    private void OnEnable() {
        PlayerInputController.OnCallUI += ShowMenu;
        GameController.Instance.OnWinEvent += ShowWinScreen;
    }

    private void ShowMenu() => _menu.EnablePanel();

    private void ShowLoseScrren() => _loseScreen.EnablePanel();

    private void ShowWinScreen() => _winScreen.EnablePanel();

    public void MainMenu() => LevelLoader.Instance.MainMenu();

    public void ContinueAsGhost() => OnResurrectClick?.Invoke();

    private void OnDisable() {
        PlayerInputController.OnCallUI -= ShowMenu;
        GameController.Instance.OnWinEvent -= ShowWinScreen;
    }
}
