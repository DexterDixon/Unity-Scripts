using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.XR.MagicLeap;
using System;

public class NetworkedOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start(); 
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        // Initializing a new pubnub Connection
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-86694f64-f8a5-4dea-a382-d99cef5f71e9";
        pnConfiguration.SubscribeKey = "sub-c-ef60f02c-80b8-11e9-bc4f-82f4a771f4c5";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = this.name;
        pnConfiguration.ReconnectionPolicy = PNReconnectionPolicy.LINEAR;

        PubNub pubNub = new PubNub(pnConfiguration);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleOnTriggerDown(byte controllerId, float value)
    {
        if (Input.GetKeyDown("space"))
        {
            this.SetActive(false);
            print("Space Pressed");
        }

    }

    private void OnDestroy()
    {
        MLInput.OnTriggerDown -= HandleOnTriggerDown;
        MLInput.Stop();
    }
}
