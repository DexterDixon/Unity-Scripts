using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public float Wait = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(EndItAll());
	}

    private IEnumerator EndItAll()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
