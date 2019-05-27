using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerAction : MonoBehaviour
{
    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean grabAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetState(hand))
        {
            Debug.Log(hand.ToString() + "Grab!");
        }
    }
}
