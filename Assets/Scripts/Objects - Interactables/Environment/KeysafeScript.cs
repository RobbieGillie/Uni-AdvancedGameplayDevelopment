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
        if (other.gameObject == player && player.GetComponent<PlayerController>().hasKey[0])
        {
            Debug.Log("You have the first key! Safe opened!");
            MsgSystem key1Success = MsgSystem.CreateInstance("You have the first key! Safe opened!", MsgType.Success);
            hud.messages.Add(key1Success);
            
            gameObject.SetActive(false);
            safe.SetActive(false);
            safeContents.SetActive(true);
        }
        else
        {
            Debug.Log("Please collect the first key!");
            MsgSystem key1Warning = MsgSystem.CreateInstance("Please collect the first key!", MsgType.Warning);
            hud.messages.Add(key1Warning);
        }
    }
}
