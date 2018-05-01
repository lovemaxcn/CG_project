using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public PlayerController player;

	private float speed = Config.BULLET_PISTOL_SPEED; 
	private int dmg = Config.BULLET_PISTOL_DAMAGE;
	private float destructTime = 0.0f;

	// Use this for initialization
	void Start () {
		this.name = Constant.PISTOL;
		player = FindObjectOfType<PlayerController>();
		Quaternion q = player.transform.localRotation;
		this.transform.localRotation = q;
		this.transform.Rotate(new Vector3(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, speed, 0));
		Vector3 curPos = this.transform.position;
		if (destructTime >= Config.BULLET_PISTOL_DESTRUCT_TIME)
			Destroy (this.gameObject);
		else
			destructTime += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
	}

	public int getDamage()
	{
		return dmg;
	}
}
