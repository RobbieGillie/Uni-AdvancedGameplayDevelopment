using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastPresentController : MonoBehaviour
{
    [SerializeField] private GameObject linkObject; //This is the object from the 
    [SerializeField] private float futureOffset = 1000;
    private Vector3 previousLocation;
    private bool hasMoved = false;
    
    //This script must be on the object from the past
    //If this object moves -> Move the future object
    ////This will in turn mean if future object moves -> DO NOTHING

    void Start()
    {
        previousLocation = this.transform.position;
    }
    void Update()
    {
        if (this.transform.position != previousLocation)
        {
            hasMoved = true; //Tell the future object to move
            previousLocation = this.transform.position;
            
            //Move the future block
            linkObject.transform.position = new Vector3(this.transform.position.x + futureOffset, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            hasMoved = false; //Stop the future object from moving
        }
    }
}
