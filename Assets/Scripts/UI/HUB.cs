using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUB : MonoBehaviour
{
    private int chosenMap;

    private void Start()
    {
        chosenMap = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(chosenMap);
    }

    public void ChoseMap(int index)
    {
        chosenMap = index;
    }
}
