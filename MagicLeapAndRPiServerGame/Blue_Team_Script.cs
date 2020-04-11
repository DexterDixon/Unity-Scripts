using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Blue_Team_Script : MonoBehaviour {
    public BucketScript Data;
    public const string Tilt = "http://192.168.1.4/tilt-left";
    public const string Mtn = "http://192.168.1.4/mountain-left";

    void Start()
    {

    }

    IEnumerator Tilt_Left()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Tilt))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator Mountain_Left()
    {
        UnityWebRequest uwr = UnityWebRequest.Get(Mtn);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);

        }

    }
    void Update()
    {


        Debug.Log("Updating...");
        if (Data.score == 8)
        {
            //Run Server
            Debug.Log("8");
            StartCoroutine(Mountain_Left());
        }

    }
}
