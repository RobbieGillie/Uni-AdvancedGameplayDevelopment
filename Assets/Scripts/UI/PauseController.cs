using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This script will handle pausing/unpausing the game directly from here
/// </summary>
public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool _isPaused;
    
    public static PauseController instance;

    void Start()
    {
        //Set this as an instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            this.GetComponent<PauseController>().enabled = false;
        }
        
        //Set the default value to false
        _isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        //Set _isPaused opposite to what the last value was
        _isPaused = !_isPaused;
        
        if (_isPaused)
        {
            //TODO: Change freezing time to stopping necessary objects directly
            Time.timeScale = 0f; //Freeze time
            pauseMenu.SetActive(true); //Show the pause menu
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }
}
