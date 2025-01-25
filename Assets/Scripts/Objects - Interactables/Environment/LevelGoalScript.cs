using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 To-do:
- Replace written Debug.Logs and created instances of HUD messages with prewritten ones
- Cinemachine UI scripts?
- Other scriptwriting for level completion
*/

public class LevelGoalScript : MonoBehaviour
{
    public GameObject player, completeUI;
    public HUDElements hud;
    public bool complete = false;
    private bool _hasAllKeys = false;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _hasAllKeys) // Check if the player has collected all keys
        {
            Debug.Log("Level Complete!");
            MsgSystem levelComplete = MsgSystem.CreateInstance("Level Complete!", MsgType.Success);
            hud.messages.Add(levelComplete);
            
            complete = true;
            completeUI.SetActive(true);
            
            
            // need to add UI and level completion scripting here
        }
        else if (other.gameObject.CompareTag("Player") && !_hasAllKeys) // If the player hasn't collected all keys
        {
            Debug.Log("Please collect the keys!");

            MsgSystem key2Warning = MsgSystem.CreateInstance("Please collect the keys!", MsgType.Warning);
            hud.messages.Add(key2Warning);
        }
    }

    private void Update()
    {
        foreach (var key in _playerController.hasKey)
        {
            if (key == false)
            {
                _hasAllKeys = false;
                break;
            }
            else
            {
                _hasAllKeys = true;
            }
        }
    }
}
