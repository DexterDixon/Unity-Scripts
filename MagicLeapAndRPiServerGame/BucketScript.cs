using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScript : MonoBehaviour {

	public int score = 0;
	public int reset = 0;
	public const string tilt_left = "192.168.1.4/tilt-left";
	public const string tilt_right = "192.168.1.4/tilt-right";
    public Text display;


    void Start()
    {
        UpdateDisplay();

    }
    void Update()
	{
        UpdateDisplay();
	}
	public void Add()
	{
		score += 1;
	}

    public void UpdateDisplay()
    {
       display.text = "Score: " + score.ToString();
    }

}


