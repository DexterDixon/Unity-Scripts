using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDspaerspace : MonoBehaviour {
    public GameObject tree;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tree.gameObject.SetActive(false);

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            tree.gameObject.SetActive(true);

        }

    }

}
