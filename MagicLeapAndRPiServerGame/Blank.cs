using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Blank : MonoBehaviour {

	public int score = 0;
	public int reset = 0;
	public const string tilt_left = "192.168.1.4/tilt-left";
	public const string tilt_right = "192.168.1.4/tilt-right";

	void Start()
	{
		StartCoroutine(GetText());
	}

	IEnumerator GetText()
	{
		using (UnityWebRequest www = UnityWebRequest.Get(tilt_left))
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

				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
		}
	}

}

