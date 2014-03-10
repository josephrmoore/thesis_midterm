using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {

	private bool over = false;
	private bool activated = false;
	private Color c, white;
	private bool note_on = false;

	public int midi_id;

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
			activated = !activated;
		}
		if(activated){
//			for(int i=0; i<12; i++){
//				MidiOut.SendNoteOff(0, i+48);
//			}
			if(note_on == false){
				MidiOut.SendNoteOn(0, midi_id+36, 1);
				note_on = true;
			}
			renderer.material.color = c;
		} else {
			if(note_on == true){
				MidiOut.SendNoteOff(0, midi_id+36);
				note_on = false;
			}
			renderer.material.color = white;
		}
	}
}



