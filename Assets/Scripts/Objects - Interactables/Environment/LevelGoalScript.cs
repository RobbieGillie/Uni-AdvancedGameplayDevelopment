using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoalScript : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player.GetComponent<PlayerController>().hasKey[1]) // Check if the player has the second key
        {
            Debug.Log("Level Complete!");
            // need to add UI and level completion scripting here
        }
        else
        {
            Debug.Log("Please collect the second key!");
        }
    }
}
