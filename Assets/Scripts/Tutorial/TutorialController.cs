using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public GameObject diePanel;

    public Transform checkpoint;

    private void Awake()
    {
        PlayerController.Instance.GetPlayerHealthController().OnPlayerDied += ShowDiePanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ResurrectPlayer();
        }
    }

    public void ResurrectPlayer()
    {
        PlayerController.Instance.GetPlayerParameters().SetIsAlive(true);
        PlayerController.Instance.GetPlayerParameters().SetIsGhost(false);
        PlayerController.Instance.GetPlayerParameters().SetIsCovered(false);
        PlayerController.Instance.SetPlayerLayer(6);
        PlayerController.Instance.GetPlayerHUDContorller().ShowHUD(); 
        PlayerController.Instance.GetPlayerGraphicsController().SetAliveGraphics();
        PlayerController.Instance.SetState(PlayerController.Instance.aliveState);
       

        PlayerController.Instance.transform.position = checkpoint.position;
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

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        this.checkpoint = checkpoint;
    }

    private void OnDisable()
    {
        PlayerController.Instance.GetPlayerHealthController().OnPlayerDied -= ShowDiePanel;
    }
}
