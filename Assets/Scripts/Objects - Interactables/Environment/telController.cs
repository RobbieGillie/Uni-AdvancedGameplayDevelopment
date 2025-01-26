using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telController : MonoBehaviour
{
    public GameObject player, telTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Tel") && other.CompareTag("Player"))
        {
            player.transform.position = telTarget.transform.position;
        }
    }

}
