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
        GameController.Instance.OnLose += ShowLoseScrren;
        GameController.Instance.OnWin += ShowWinScreen;
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
        PlayerController.Instance.SetState(PlayerController.Instance.ghostState);
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        GameController.Instance.OnLose -= ShowLoseScrren;
        GameController.Instance.OnWin -= ShowWinScreen;
    }
}
