﻿using UnityEngine;
using System.Collections;

public class bd3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().mute = true;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "rhythm"){
			if (Input.GetKey (KeyCode.C)) {
				GetComponent<AudioSource> ().mute = false;
			} else if(Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Z) || Input.GetKey (KeyCode.V)){
				GetComponent<AudioSource> ().mute = true;
			}
		}
	}
}
