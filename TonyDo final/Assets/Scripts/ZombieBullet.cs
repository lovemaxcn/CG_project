using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : MonoBehaviour {
	public PlayerController player;
	private float time = 0;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		float degree = MyUtils.calculateZombieRotate (player.transform.position.x, player.transform.position.z, transform.position.x, transform.position.z);
		Quaternion q = transform.rotation;
		q.y = degree;
		//transform.rotation = q;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > Config.ZOMBIE_BULLET_DESTRUCT_TIME)
			Destroy (gameObject);
		transform.Translate (new Vector3 (0, 0, Config.ZOMBIE_BULLET_SPEED));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals (Constant.TAG_PLAYER))
			Destroy (gameObject);
	}
}
