using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour {
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals (Constant.TAG_PLAYER)) {
			Destroy (gameObject);
			gameController.playerGetItem ();
		}
	}
}
