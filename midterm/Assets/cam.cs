using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i=0; Camera.allCameras.Length>i; i++)
		{
			if(networkView.isMine == false)
			{
				Destroy(Camera.allCameras[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}