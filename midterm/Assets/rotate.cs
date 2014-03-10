using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	public float rotationSpeed = 10.0f;
	public float lerpSpeed = 1.0f;
	
	private Vector3 speed = new Vector3();
	private Vector3 avgSpeed = new Vector3();
	private bool dragging = false;
	private bool rotating = false;
	
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
//			Debug.Log (speed);
		}
		
		transform.Rotate(Vector3.back, speed.x * rotationSpeed, Space.World);

		if((int)(speed.x*127)*(int)rotationSpeed>0){
			rotating = true;
		} else {
			rotating = false;
		}
		Debug.Log (rotating);
		if(rotating == true){
			MidiOut.SendPitchBend (0, 0, (int)(speed.x*127)*(int)rotationSpeed);
		}
	}
}



