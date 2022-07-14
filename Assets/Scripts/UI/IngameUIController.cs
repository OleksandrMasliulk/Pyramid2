using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUIController : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;
    public SidePanel menu;

    private void Start()
    {
        GameController.Instance.OnLoseEvent += ShowLoseScrren;
        GameController.Instance.OnWinEvent += ShowWinScreen;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!menu.isActiveAndEnabled)
                    menu.ShowPanel();
                else
                {
                    menu.HidePanel();
                }
            }
        }
    }

    private void ShowLoseScrren()
    {
        loseScreen.SetActive(true);
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ContinueAsGhost()
    {
        UnitManager.Instance.PlayerList[0].SetState(UnitManager.Instance.PlayerList[0].ghostState);
    }

    public void MainMenu()
    {
        LevelLoader.Instance.MainMenu();
    }

    private void OnDisable()
    {
        GameController.Instance.OnLoseEvent -= ShowLoseScrren;
        GameController.Instance.OnWinEvent -= ShowWinScreen;
    }
}
