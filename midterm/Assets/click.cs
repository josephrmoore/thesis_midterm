using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {

	private bool over = false;
	private bool active = false;
	private Color c, white;

	void OnMouseOver() 
	{
		over = true;
	}
	void OnMouseExit(){
		over = false;
	}
	
	// Use this for initialization
	void Start () {
		c = renderer.material.color;
		white = new Color (1,1,1,1);
		renderer.material.color = white;
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetMouseButtonDown(0) && over) {
			active = !active;
		}
		if(active){
			renderer.material.color = c;
		} else {
			renderer.material.color = white;
		}
	}
}



