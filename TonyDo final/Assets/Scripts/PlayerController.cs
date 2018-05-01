using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject bullet;
	public GameObject bulletPosition;

	private int hp = Config.PLAYER_HP;
	private Animator anim;
	private float atkCooldown = 0;
	private int currentGun = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		atkCooldown += Time.deltaTime;

		Vector3 mouseLocation = Input.mousePosition;
		anim.SetBool("isMoving", false);
		transform.eulerAngles = new Vector3(0, MyUtils.calculatePlayerRotate(mouseLocation.x, mouseLocation.y, Screen.width, Screen.height), 0);

		float vertMove = 0, horMove = 0;

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			anim.SetBool("isMoving", true);
			if(Input.GetKey(KeyCode.W))
				vertMove = Config.PLAYER_MOVE_SPEED;
			else
				vertMove = - Config.PLAYER_MOVE_SPEED;
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			anim.SetBool("isMoving", true);
			if (Input.GetKey (KeyCode.D))
				horMove = Config.PLAYER_MOVE_SPEED;
			else
				horMove = - Config.PLAYER_MOVE_SPEED;
		}
		if (Mathf.Abs (horMove) > 0 && Mathf.Abs (vertMove) > 0) {
			horMove = horMove / Mathf.Sqrt (2);
			vertMove = vertMove / Mathf.Sqrt (2);
		}
		GetComponent<Rigidbody> ().velocity = new Vector3 (horMove, 0, vertMove);

		if (Input.GetMouseButton(0) && atkCooldown > MyUtils.getAttackSpeedForGun(currentGun))
		{
			attack ();
		}
	}

	private void attack(){
		atkCooldown = 0;
		Instantiate (bullet, bulletPosition.transform.position, Quaternion.identity);
	}

	void OnTriggerEnter(Collider other){
		int damageTaken = MyUtils.getMonsterDamageByTag (other.gameObject.tag);
		hp -= damageTaken;
	}

	public int getHp(){
		return this.hp;
	}
}
