using UnityEngine;
using System;

public class IngameUIController : MonoBehaviour {
    public static event Action OnGhostClick;

    [SerializeField] private UIPanel _loseScreen;
    [SerializeField] private UIPanel _winScreen;
    [SerializeField] private UIPanel _menu;

    public void OnEnable() => PlayerInputController.OnCallUI += ShowMenu;

    private void ShowMenu() => _menu.EnablePanel();

    private void ShowLoseScrren() => _loseScreen.EnablePanel();

    private void ShowWinScreen() => _winScreen.EnablePanel();

    public void MainMenu() => LevelLoader.Instance.MainMenu();

    public void ContinueAsGhost() => OnGhostClick?.Invoke();

    private void OnDestroy() => PlayerInputController.OnCallUI -= ShowMenu;
}
