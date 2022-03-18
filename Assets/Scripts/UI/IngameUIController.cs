using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUIController : MonoBehaviour
{
    public GameObject loseScreen;

    private void Start()
    {
        GameController.Instance.OnLose += ShowLoseScrren;
    }

    private void ShowLoseScrren()
    {
        loseScreen.SetActive(true);
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
    }

    private void OnDisable()
    {
        GameController.Instance.OnLose -= ShowLoseScrren;
    }
}
