using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;

    public GameObject gameOverUI;

    private void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (gameEnded)

            return;
        
        if(PlayerStat.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);

    }
}
