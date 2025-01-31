using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysafeScript : MonoBehaviour
{
    public GameObject player;
    public HUDElements hud;
    public GameObject safe;
    public GameObject safeContents;

    private void OnTriggerEnter(Collider other)
    {
        //If the player has collided with this
        if (other.gameObject == player)
        {
            //Check what key the player has
            if (player.GetComponent<PlayerController>().hasKey[0])
            {
                Debug.Log("You have the first key! Safe opened!");
                MsgSystem key1Success =
                    MsgSystem.CreateInstance("You have the first key! Safe opened!", MsgType.Success);
                hud.messages.Add(key1Success);

                gameObject.SetActive(false);
                safe.SetActive(false);
                safeContents.SetActive(true);
            }
            else if(player.GetComponent<PlayerController>().hasKey[1]) //Example: Key 2
            {
                Debug.Log("Keysafe: You have the secon key! Safe opened!");
            }
        }
        else //The player does not have a key
        {
            Debug.Log("Please collect the first key!");
            MsgSystem key1Warning = MsgSystem.CreateInstance("Please collect the first key!", MsgType.Warning);
            hud.messages.Add(key1Warning);
        }
    }
}
