using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public int speed;
    private bool moving = false;
    private Vector3 directionVector;
    private Vector3 targetLocation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
           // Vector3 startpositionDifference = transform.position;
            transform.Translate(directionVector * speed * Time.deltaTime);
            if ((transform.position - targetLocation).magnitude >= -speed * Time.deltaTime && (transform.position - targetLocation).magnitude <= speed*Time.deltaTime)
            {
                moving = false;
            }
            return;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
    
    public void moveTo(float x, float y)
    {
        targetLocation = new Vector3(x, y, transform.position.z);
        directionVector = targetLocation - transform.position;
        directionVector.Normalize();
        moving = true;
    }
}
