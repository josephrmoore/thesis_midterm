using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	public string gameName = "Joe_Moore_Thesis_Midterm";
	public GameObject playerPrefab1;
	public GameObject playerPrefab2;
	public Transform spawnObjectServer;
	public Transform spawnObjectClient;
	private float bX, bY, bW, bH;
	private bool refreshing;
	private HostData[] hostData;

	// Use this for initialization
	void Start () {
		bX = Screen.width * 0.05f;
		bY = Screen.width * 0.05f;
		bW = Screen.width * 0.1f;
		bH = Screen.width * 0.1f;
		hostData = new HostData[0];
	}
	// Update is called once per frame
	void Update () {
		if(refreshing){
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				hostData = MasterServer.PollHostList();
				Debug.Log (MasterServer.PollHostList().Length);
			}
		}
//		if(Network.isClient){
//			Camera.main.transform.position = playerPrefab.transform.position;
//		}
	}

	void startServer(){
		Network.InitializeServer (2, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameName, "Collaborative Music Mayhem", "This is a musical toy.");

	}

	void refreshHostList(){
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	}

	void spawnPlayer(GameObject p, Transform spawn){

		Destroy (Camera.main);
		GameObject player = Network.Instantiate (p, spawn.position, Quaternion.identity, 0) as GameObject;
		if(spawn == spawnObjectClient){
			player.transform.Rotate(new Vector3(0,180,0));	
		}
		if(player.networkView.isMine){ //check to make sure it’s out player being spawned
			Camera[] c = player.GetComponentsInChildren<Camera>();
			Debug.Log (c[0]);
			c[0].tag = "MainCamera";
			Debug.Log (c[0].tag);
		
		}


	}

	void OnServerInitialized(){
		Debug.Log ("Server Initialized");
		spawnPlayer (playerPrefab1, spawnObjectServer);
	}

	void OnConnectedToServer(){
		spawnPlayer (playerPrefab2, spawnObjectClient);
	}

	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log ("Registered to Master Server.");
		}
	}

	void OnGUI(){
		if(!Network.isClient && !Network.isServer){
			if(GUI.Button(new Rect(bX,bY,bW,bH), "Start Server")){
				startServer();
			}
			if(GUI.Button(new Rect(bX,bY*1.2f+bH,bW,bH), "Refresh Hosts")){
				refreshHostList();
			}
			if(hostData.Length > 0){
				for(int i=0; i<hostData.Length; i++){
					if(GUI.Button(new Rect(bX*1.5f+bW,bY*1.2f+(bH*i),bW*2f,bH*0.5f), hostData[i].gameName)){
						Network.Connect(hostData[i]);
					}
				}
			}
		}
	}

}
