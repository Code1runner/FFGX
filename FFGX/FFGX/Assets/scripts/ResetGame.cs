using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool isPaused=false;
    public GameObject EndGameMenuUI;
    public Transform player;
    float pointSave;
    // Start is called before the first frame update

    public void Start()
    {
        pointSave = -1;
    }
    public void RestartGame()
    {
        pointSave = -1;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EndGameMenuUI.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                pointSave = -1;
                isPaused = true;
            }
        }
    }

    public void LateUpdate()
    {
        if (!isPaused)
        {
            if ((pointSave == player.position.z) && !gameHasEnded)
            {
                EndGameMenuUI.SetActive(true);
                Time.timeScale = 0f;
                gameHasEnded = true;
            }
            else
            {
                pointSave = player.position.z;
            }
        }
        
    }

}

