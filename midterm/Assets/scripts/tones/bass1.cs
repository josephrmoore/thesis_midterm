﻿using UnityEngine;
using System.Collections;

public class bass1 : MonoBehaviour {
	int w1, w2;

	public loop_tones l;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().mute = true;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "tones"){
//			w1 = Camera.main.GetComponent<loop_tones>().wheel1;
//			w2 = Camera.main.GetComponent<loop_tones>().wheel2;
//			if (w1 == 0 && w2 == 0) {
//				GetComponent<AudioSource> ().mute = false;
//			} else if((w1 == 0 && w2 == 1) || (w1 == 0 && w2 == 2) || (w1 == 0 && w2 == 3)){
//				GetComponent<AudioSource> ().mute = true;
//			}
			if (Camera.main.GetComponent<loop_tones>().wheel1 == 0) {
				GetComponent<AudioSource> ().mute = false;
			} else {
				GetComponent<AudioSource> ().mute = true;
			}
		}
	}
}
