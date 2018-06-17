using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
    private Light light;
    private bool turnedOn = true;
    private float lastTimeSwitched;
    private float switchRateLimit = 0.2f;
    private float originalIntensity;

	// Use this for initialization
	void Start () {
        light = gameObject.GetComponent(typeof(Light)) as Light;
        originalIntensity = light.intensity;
        lastTimeSwitched = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float switchPushed = Input.GetAxis("Fire3");
        if (switchPushed == 1 && Time.time > (lastTimeSwitched + switchRateLimit))
        {
            lastTimeSwitched = Time.time;
            if(turnedOn)
            {
                turnedOn = false;
                light.intensity = 0;
            }
            else
            {
                turnedOn = true;
                light.intensity = originalIntensity;
            }
        }
    }
}
