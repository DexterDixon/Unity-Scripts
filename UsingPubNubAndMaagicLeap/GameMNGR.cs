using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class GameMNGR : MonoBehaviour
{
    //Variable Initialization
    private PubNub pubnub;
    public Renderer CubeRenderer;
    public GameObject  Blue_HUD;
    public GameObject  Red_HUD;
    public GameObject Team_Selector;
    public Renderer controllerRend;
    public Renderer Object1;
    public Renderer Object2;
    public Renderer Object3;
    public Material controllerBlue;
    public Material controllerRed;

    private bool BlueTeamSelect;
    private bool TeamSelectStatus = true;
    public Text Instructions;
    //Meshing Variables
    private static readonly Vector3 _boundedExtentsSize = new Vector3(2.0f, 2.0f, 2.0f);
    private static readonly Vector3 _boundlessExtentsSize = new Vector3(10.0f, 10.0f, 10.0f);
    private bool _bounded = false;
    private MLSpatialMapper _mlSpatialMapper = null;
    public Camera _camera = null;

    void Start()
    {
        //Brings up Team Selectoin Menue
        Team_Selector.SetActive(true);
        Blue_HUD.SetActive(false);
        Red_HUD.SetActive(false);

        while (TeamSelectStatus == true)
        {

        }

        //Brings up HUD for coresponding team
        if(BlueTeamSelect == false)
        {
            Blue_HUD.SetActive(false);
            Red_HUD.SetActive(true);
        }
        else
        {
            Blue_HUD.SetActive(true);
            Red_HUD.SetActive(false);
        }

        //Changes Controller Material to match team
        if (BlueTeamSelect == false)
        {
            controllerRend.material = controllerRed;

        }
        else
        {
            controllerRend.material = controllerBlue;
        }

        _mlSpatialMapper.gameObject.transform.position = _camera.gameObject.transform.position;
        _mlSpatialMapper.gameObject.transform.localScale = _bounded ? _boundedExtentsSize : _boundlessExtentsSize;

        // Initializing a new pubnub Connection
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-86694f64-f8a5-4dea-a382-d99cef5f71e9";
        pnConfiguration.SubscribeKey = "sub-c-ef60f02c-80b8-11e9-bc4f-82f4a771f4c5";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = "GameMNGR";
        pnConfiguration.ReconnectionPolicy = PNReconnectionPolicy.LINEAR;

        PubNub pubnub = new PubNub(pnConfiguration);
   
        //Sets up Subscriber Callback which handles received messages
        pubnub.SubscribeCallback += (sender, e) => {
            SubscribeEventEventArgs mea = e as SubscribeEventEventArgs;

            if (mea.MessageResult != null)
            {

                if(mea.MessageResult.Payload == "BumperPress")
                {
                    CubeRenderer.enabled = false;
                }
                else
                {
                    CubeRenderer.enabled = true;
                }
            }

        };

        //Subscribes to channels in list
        pubnub.Subscribe()
        .Channels(new List<string>() {
        "cube"
        })
        .Execute();
    }

     void OnDestroy()
    {
        pubnub.CleanUp();

    }
    // Functions for Team Selection buttons
    public void SelectBlue()
    {
        BlueTeamSelect = true;
        Team_Selector.SetActive(false);
    }

    public void SelectRed()
    {
        BlueTeamSelect = false;
        Team_Selector.SetActive(false);
    }

    void Update()
    {
        
    }
}
