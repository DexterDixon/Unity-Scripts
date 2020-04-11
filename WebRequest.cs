using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    string text;
    const string url = "http://192.168.1.232:5000/hedgePos";

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     StartCoroutine(ping(url));

    }
    IEnumerator ping(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received" + uwr.downloadHandler.text);
        }
    }
}
