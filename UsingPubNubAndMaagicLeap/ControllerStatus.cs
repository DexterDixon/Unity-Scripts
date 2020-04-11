using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using PubNubAPI;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap
{
    public class ControllerStatus : MonoBehaviour
    {
        public ControllerConnectionHandler _controllerConnectionHandler = null;
        public Vector3 position;
        public Vector3 angle;
        public Vector3 touchpad;
        public float trigger;
        public bool bumper;
        public bool touchpadActive;

        // Start is called before the first frame update
        void Start()
        {
            PNConfiguration pnConfiguration = new PNConfiguration();
            pnConfiguration.PublishKey = "pub-c-86694f64-f8a5-4dea-a382-d99cef5f71e9";
            pnConfiguration.SubscribeKey = "sub-c-ef60f02c-80b8-11e9-bc4f-82f4a771f4c5";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.UUID = "MagicLeap";
            pnConfiguration.ReconnectionPolicy = PNReconnectionPolicy.LINEAR;
            PubNub pubnub = new PubNub(pnConfiguration);


            MLInput.Start(); 
            MLInput.OnTriggerDown += HandleOnTriggerDown;
        }

        void OnDestroy()
        { 
            
            MLInput.OnTriggerDown -= HandleOnTriggerDown;
            MLInput.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            if (_controllerConnectionHandler.IsControllerValid())
            {
                MLInputController controller = _controllerConnectionHandler.ConnectedController;
                if (controller.Type == MLInputControllerType.Control)
                {
                    position = controller.Position;
                    angle = controller.Orientation.eulerAngles;
                    trigger = controller.TriggerValue;
                    bumper = controller.IsBumperDown;
                    touchpad = controller.Touch1PosAndForce;
                    touchpadActive = controller.Touch1Active;
                }
            }
        }

        void HandleOnTriggerDown(byte controllerId, float value)
        {
            PNConfiguration pnConfiguration = new PNConfiguration();
            pnConfiguration.PublishKey = "pub-c-86694f64-f8a5-4dea-a382-d99cef5f71e9";
            pnConfiguration.SubscribeKey = "sub-c-ef60f02c-80b8-11e9-bc4f-82f4a771f4c5";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.UUID = "MagicLeap";
            pnConfiguration.ReconnectionPolicy = PNReconnectionPolicy.LINEAR;
            PubNub pubnub = new PubNub(pnConfiguration);


            pubnub.Publish()
                .Channel("cube")
                .Message("BumperPress")
                .Async((result, status) => {
                    if (!status.Error)
                    {
                        Debug.Log("Bumper Press");
                    }
                    else
                    {
                        Debug.Log(status.Error);
                        Debug.Log(status.ErrorData.Info);
                       }
                   });
        }
    }
}