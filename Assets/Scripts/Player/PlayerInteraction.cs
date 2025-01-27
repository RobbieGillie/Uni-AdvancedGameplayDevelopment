using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private bool canInteract;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    
    void Update()
    {
        Interact();
    }
    private void Interact()
    {
        if (Input.GetKeyDown(interactKey) && canInteract)
        {
            //TODO: Complete this
        }
    }
}
