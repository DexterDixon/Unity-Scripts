using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Red_Team_Script : MonoBehaviour
{
    public BucketScript Data;
    public const string url = "https://192.168.0.198/tilt-left";
    public Text winstatus;
    public string idol_status = "Idole Platform Status: ";
    string placeholder;

    void Start()
    {
     UpdateDisplay();
    }

    IEnumerator Tilt_Left(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            placeholder = uwr.downloadHandler.text;
        }
    }

    void Update()
    {
        UpdateDisplay();
        Debug.Log("Updating...");
        if (Data.score == 8)
        {
            //Run Server
            Debug.Log("8");
            StartCoroutine(Tilt_Left(url));
            idol_status = "Idole Platform Status: Activated";
        }
    }

    public void UpdateDisplay()
    {
        winstatus.text = idol_status;
    }
}
