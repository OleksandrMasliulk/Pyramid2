using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public delegate void OnWinDelegate();
    public event OnWinDelegate OnWin;
    public delegate void OnLoseDelegate();
    public event OnWinDelegate OnLose;

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

    public void Win()
    {
        OnWin?.Invoke();
    }

    public void Lose()
    {
        Debug.LogWarning("!!! PLAYER LOST !!!");

        OnLose?.Invoke();
    }
}
