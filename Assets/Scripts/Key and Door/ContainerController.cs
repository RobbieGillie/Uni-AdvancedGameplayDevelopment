using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Some kind of chest type system. It seems to simply enable an object when it is 
/// </summary>
public class ContainerController : MonoBehaviour, IInteraction
{
    [Header("Container Settings")]
    [SerializeField] private string contName;
    [SerializeField] private string requiredKey;
    [SerializeField] private bool needsKey;
    
    [Header("Container References")]
    [SerializeField] private GameObject containerObject;
    [SerializeField] private GameObject contents;

    public void Start()
    {
        if (!needsKey)
        {
            requiredKey = null;
        }
    }

    public virtual void Interact()
    {
        //No key is required, open the container
        if (requiredKey == null && !needsKey)
        {
            OpenContainer();
            return;
        }

        //Key is required, none assigned: Log error
        if (requiredKey == null && needsKey)
        {
            Debug.LogError($"Error: No key was set for the container: {contName}. Please set a key or disable the needsKey option.");
            return;
        }

        //Check if the player has the required key
        if (KeyController.instance.CheckKeyChain(requiredKey))
        {
            KeyController.instance.RemoveKey(requiredKey); //Remove the key after use
            OpenContainer();
            
            //TODO: Replace with animation for different container types
        }
        else
        {
            Debug.Log($"The player does not have the key: {requiredKey}");
        }
    }
    
    //Helper Function: Handles opening the container
    private void OpenContainer()
    {
        containerObject.SetActive(false); //Hide the container
        if (!contents.activeSelf)
        {
            contents.SetActive(true);  //Show the contents
        }
    }
}
