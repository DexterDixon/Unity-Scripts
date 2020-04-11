using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pots : MonoBehaviour {

    public BucketScript Data;

    public ParticleSystem Particle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Data.Add();
            ParticleSystem ps = Instantiate(Particle, this.transform.position, Quaternion.identity) as ParticleSystem;
            this.gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Data.Add();
        ParticleSystem ps = Instantiate(Particle, this.transform.position, Quaternion.identity) as ParticleSystem;
        this.gameObject.SetActive(false);
        Destroy(other.gameObject);

    }
}
