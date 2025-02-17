using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// This script will handle unlocking the door
/// </summary>
public class DoorController : MonoBehaviour, IInteraction
{
    [SerializeField] private string requiredKey;
    private bool isDoorLocked = true;
    [SerializeField] private GameObject doorObject;
    
    public virtual void Interact()
    {
        bool hasKey = KeyController.instance.CheckKeyChain(requiredKey);

        if (hasKey)
        {
            //Unlock the door
            isDoorLocked = false;
            
            //Remove the key from the keyChain
            KeyController.instance.RemoveKey(requiredKey);
            
            switch (requiredKey)
            {
                //Check what type of door this is - Door or vent
                default:
                    this.GetComponent<BoxCollider>().enabled = false; //Stops re-triggering the door
                    doorObject.GetComponent<Animation>().Play("DoorOpenAnim");
                    break;
                
                //for vent door
                case "Key_Screwdriver":
                    doorObject.SetActive(false);
                    break;
                
                //TODO: Vent door animation needed
            }
        }
        else
        {
            //The player does not have the key
            Debug.Log("The player does not have the key: " + requiredKey);
        }
    }
}
