using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.transform.position + new Vector3(0, 11, -3.5f);
	}
}
