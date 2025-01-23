using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysafeScript : MonoBehaviour
{
    public GameObject player;
    public GameObject safe;
    public GameObject safeContents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && player.GetComponent<PlayerController>().hasKey[0])
        {
            Debug.Log("You have the first key! Safe opened!");
            gameObject.SetActive(false);
            safe.SetActive(false);
            safeContents.SetActive(true);
        }
        else
        {
            Debug.Log("Please collect the first key!");
        }
    }
}
