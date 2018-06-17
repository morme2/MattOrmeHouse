using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    private Vector3 startPosition;
    private Vector3 openPosition;
    private Rigidbody rigidbody;
    private bool open = false;
    private float openRate = 0.2f;
    private float lastOpenTime = 0;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
        startPosition = rigidbody.position;
        openPosition = new Vector3
        (
            startPosition.x + (rigidbody.transform.localScale.z / 2),
            startPosition.y,
            startPosition.z + (rigidbody.transform.localScale.z / 2)
        );
    }
	
	// Update is called once per frame
	void Update () {
        float openPushed = Input.GetAxis("Jump"); // space key is mapped to Jump, so jump is used for convenience
        if(openPushed == 1 && (Time.time > lastOpenTime + openRate)) // check for button push and time since last open
        {
            lastOpenTime = Time.time;
            if (open)
            {   
                rigidbody.transform.position = startPosition;
                rigidbody.transform.Rotate(0, -90, 0);
                rigidbody.velocity = new Vector3(0, 0, 0);
                open = false;
            }
            else
            {
                rigidbody.transform.position = openPosition;
                rigidbody.transform.Rotate(0, 90, 0);
                rigidbody.velocity = new Vector3(0, 0, 0);
                open = true;
            }
        }
    }
}
