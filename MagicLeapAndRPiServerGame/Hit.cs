using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

public string url = "192.168.1.137/?toggle";
public GameObject target;



	void OnTriggerEnter(Collider target)
{

	

			
	using (WWW www = new WWW(url))
	{
	//	yield return www;
	}
		
			}
}



