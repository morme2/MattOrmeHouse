using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehavior : MonoBehaviour {
    private enum PowerLevel {OFF, LOW, MED, HIGH};
    private PowerLevel currentLevel = PowerLevel.OFF;
    private float currentSpeed = 0;
    private float buttonRate = 0.2f;
    private float lastButtonTime = 0;
    private float rampUpSpeed = 60;

    // Use this for initialization
    void Start () {
		// do nothing
	}
	
	// Update is called once per frame
	void Update () {
        float buttonPushed = Input.GetAxis("Fire1"); // get button push
        if(buttonPushed == 1 && Time.time > lastButtonTime + buttonRate)
        {
            currentLevel = getNextLevel(currentLevel);
            lastButtonTime = Time.time;
        }
        currentSpeed += (getRotateSpeed(currentLevel) - currentSpeed) / rampUpSpeed;
        transform.Rotate(0, currentSpeed, 0);
    }

    private float getRotateSpeed(PowerLevel level)
    {
        switch(level)
        {
            case PowerLevel.OFF:
                return 0.0f;
            case PowerLevel.LOW:
                return 5f;
            case PowerLevel.MED:
                return 10f;
            case PowerLevel.HIGH:
                return 15f;
            default:
                return 0.0f;
        }
    }

    private PowerLevel getNextLevel(PowerLevel level)
    {
        switch (level)
        {
            case PowerLevel.OFF:
                return PowerLevel.LOW;
            case PowerLevel.LOW:
                return PowerLevel.MED;
            case PowerLevel.MED:
                return PowerLevel.HIGH;
            case PowerLevel.HIGH:
                return PowerLevel.OFF;
            default:
                return PowerLevel.OFF;
        }
    }
}
