using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour {
	public GameObject zombieBullet;
	public Transform bulletPosion;

	private Animator anim;
	private PlayerController player;
	private Rigidbody rigidbody;

	private int hp = Config.ZOMBIE_NORMAL_HP;
	private float attackTime = Config.ZOMBIE_NORMAL_ATTACK_TIME;
	private float delayAfterAttack = Config.ZOMBIE_DELAY_AFTER_ATTACK;

	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool(Constant.ZOMBIE_ANIM_WALKING, true);
		player = FindObjectOfType<PlayerController>();
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetBool(Constant.ZOMBIE_ANIM_DEAD))
			return;
		attackTime -= Time.deltaTime;
		delayAfterAttack -= Time.deltaTime;
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);

		float degree = MyUtils.calculateZombieRotate (player.transform.position.x, player.transform.position.z, transform.position.x, transform.position.z);
		transform.eulerAngles = new Vector3(0, degree, 0);

		float distance = MyUtils.calculateDistance (this.transform.position, player.transform.position);
		if (distance < Config.ZOMBIE_NORMAL_ATTACK_RANGE) {
			rigidbody.velocity = new Vector3 (0, 0, 0);
			attack ();
		}
		else
			chasePlayer ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals(Constant.TAG_BULLET)) {
			Bullet bullet = other.gameObject.GetComponent<Bullet>();
			hp -= bullet.getDamage();
			if (hp < 1) {
				anim.SetBool(Constant.ZOMBIE_ANIM_DEAD, true);
				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<Collider>());
				this.Invoke("DestroyZombie", Config.MONSTER_DESTROY_TIME);
			}
			Destroy(other.gameObject);
		}
	}

	void chasePlayer(){
		anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, true);
		anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, false);
		if (delayAfterAttack < 0) {
			float deg = transform.eulerAngles.y;
			GetComponent<Rigidbody> ().velocity = new Vector3 (Mathf.Sin (deg * Mathf.Deg2Rad) * Config.ZOMBIE_MOVE_SPEED, 0, Mathf.Cos (deg * Mathf.Deg2Rad) * Config.ZOMBIE_MOVE_SPEED);
		} else
			delayAfterAttack -= Time.deltaTime;
	}

	void attack(){
		if (attackTime < 0) {
			anim.SetBool (Constant.ZOMBIE_ANIM_WALKING, false);
			anim.SetBool (Constant.ZOMBIE_ANIM_ATTACKING, true);

			Quaternion q = transform.rotation;
			Instantiate (zombieBullet, bulletPosion.position, q);

			attackTime = Config.ZOMBIE_NORMAL_ATTACK_TIME;
			delayAfterAttack = Config.ZOMBIE_DELAY_AFTER_ATTACK;
		}
	}

	void OnCollisionEnter(Collision other){
	}

	void DestroyZombie(){
		Destroy(this.gameObject);
	}
}
