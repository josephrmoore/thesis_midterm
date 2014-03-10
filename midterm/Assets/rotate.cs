using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	public float rotationSpeed = 10.0f;
	public float lerpSpeed = 1.0f;
	
	private Vector3 speed = new Vector3();
	private Vector3 avgSpeed = new Vector3();
	private bool dragging = false;
	private Vector3 targetSpeedX = new Vector3();
	
	void OnMouseOver() 
	{
		dragging = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0) && dragging) {
			speed = new Vector3(-Input.GetAxis ("Mouse X"), Input.GetAxis("Mouse Y"), 0);
			avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
		} else {
			if (dragging) {
				speed = avgSpeed;
				dragging = false;
			}
			float i = Time.deltaTime * lerpSpeed;
			speed = Vector3.Lerp( speed, Vector3.zero, i);
		}
		
		transform.Rotate(Vector3.back, speed.y * rotationSpeed, Space.World);
	}
}



