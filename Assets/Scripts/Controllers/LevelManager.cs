using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public int CurrentLevel => SceneManager.GetActiveScene().buildIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ReloadLevel()
    {
        LoadLevel(CurrentLevel);
    }

    public void MainMenu()
    {
        LoadLevel(0);
    }

    public void LoadHUB()
    {
    }
}
