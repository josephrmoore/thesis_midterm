using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public int speed, gravity;
	private CharacterController cc;
	private Component[] c;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
//		c = GetComponentsInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(networkView.isMine){
			cc.Move(new Vector3((Input.GetAxis("Horizontal")*speed*Time.deltaTime), (-gravity*Time.deltaTime), (Input.GetAxis("Vertical")*speed*Time.deltaTime)));
		} else {
			enabled = false;
		}
	}

}
