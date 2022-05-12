using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject diePanel;
    public SidePanel tutorialPanel;

    private void Awake()
    {
        PlayerController.Instance.GetPlayerHealthController().OnPlayerDied += ShowDiePanelDelayed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!tutorialPanel.isActiveAndEnabled)
                tutorialPanel.ShowPanel();
            else
            {
                tutorialPanel.HidePanel();
            }
        }
    }

    public void ResurrectPlayer(Transform pos)
    {
        PlayerController.Instance.GetPlayerParameters().SetIsAlive(true);
        PlayerController.Instance.GetPlayerParameters().SetIsGhost(false);
        PlayerController.Instance.GetPlayerParameters().SetIsCovered(false);
        PlayerController.Instance.SetPlayerLayer(6);
        PlayerController.Instance.GetPlayerHUDContorller().ShowHUD(); 
        PlayerController.Instance.GetPlayerGraphicsController().SetAliveGraphics();
        PlayerController.Instance.SetState(PlayerController.Instance.aliveState);
        PlayerController.Instance.GetPlayerSanityController().UpdateSanity(100);

        PlayerController.Instance.transform.position = pos.position;
    }

    public void SetGhost()
    {
        PlayerController.Instance.GetPlayerGraphicsController().SetGhostGraphics();
        PlayerController.Instance.SetPlayerLayer(11);
        PlayerController.Instance.GetPlayerParameters().SetIsGhost(true);
        PlayerController.Instance.SetState(PlayerController.Instance.ghostState);
    }



    public void ShowDiePanel()
    {
        diePanel.SetActive(true);
    }

    public void ShowDiePanelDelayed()
    {
        Invoke("ShowDiePanel", .5f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        PlayerController.Instance.GetPlayerHealthController().OnPlayerDied -= ShowDiePanelDelayed;
    }
}
