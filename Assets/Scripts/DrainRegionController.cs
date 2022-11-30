using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainRegionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //Debug.Log("Enter drain area");
        StateNameController.mouseOverDrainArea = true;
    }

    private void OnMouseExit()
    {
        //Debug.Log("Exit drain area");
        StateNameController.mouseOverDrainArea = false;
    }
}
