using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : GameController
{
    public GameObject tutorialDiePanel;
    public GameObject tutorialWinPanel;
    public SidePanel tutorialPanel;

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

    protected override void OnWin()
    {
        tutorialWinPanel.SetActive(true);
    }

    protected override void OnLose()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<GameActionsSoundBoard>().playerLost);
        ShowDiePanelDelayed();
    }

    public void ResurrectPlayer(Transform pos)
    {
        UnitManager.Instance.PlayerList[0].Stats.IsAlive = true;
        UnitManager.Instance.PlayerList[0].Stats.IsGhost = false;
        UnitManager.Instance.PlayerList[0].Stats.IsCovered = false;
        UnitManager.Instance.PlayerList[0].SetPlayerLayer(6);
        UnitManager.Instance.PlayerList[0].HUDController.ShowHUD();
        UnitManager.Instance.PlayerList[0].GraphicsController.SetAliveGraphics();
        UnitManager.Instance.PlayerList[0].SetState(UnitManager.Instance.PlayerList[0].aliveState);
        UnitManager.Instance.PlayerList[0].SanityController.UpdateSanity(100);

        UnitManager.Instance.PlayerList[0].transform.position = pos.position;
    }

    public void SetGhost()
    {
        UnitManager.Instance.PlayerList[0].GraphicsController.SetGhostGraphics();
        UnitManager.Instance.PlayerList[0].SetPlayerLayer(11);
        UnitManager.Instance.PlayerList[0].Stats.IsGhost = true;
        UnitManager.Instance.PlayerList[0].SetState(UnitManager.Instance.PlayerList[0].ghostState);
    }

    public void ShowDiePanel()
    {
        tutorialDiePanel.SetActive(true);
    }

    public void ShowDiePanelDelayed()
    {
        Invoke("ShowDiePanel", .5f);
    }

    public void MainMenu()
    {
        LevelLoader.Instance.MainMenu();
    }
}
