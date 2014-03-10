using UnityEngine;
using System.Collections;

public class playnote : MonoBehaviour {
	public int[] notes;
	public int octave;

	// Use this for initialization
	void Start () {
		octave = 4;
		notes = new int[12];
		for(int i=0; i<12; i++){
			notes[i] = (octave*12)+i;
		}
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.anyKeyDown){
//			MidiOut.SendNoteOn (0, 130, 100);
//		}
	}
}
