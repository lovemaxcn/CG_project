using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {
	/* ========================================
					FOR MONSTER
	========================================= */
	public static float MONSTER_DESTROY_TIME = 2.5f;
	public static int GENERATE_PERCENT_SKELETON = 50;
	public static int GENERATE_PERCENT_ZOMBIE = 40;

	public static int ZOMBIE_NORMAL_HP = 6;
	public static int ZOMBIE_DAMAGE = 7;
	public static float ZOMBIE_NORMAL_ATTACK_TIME = 2.0f;
	public static float ZOMBIE_NORMAL_ATTACK_RANGE = 8.0f;
	public static float ZOMBIE_MOVE_SPEED = 3.5f;
	public static float ZOMBIE_DELAY_AFTER_ATTACK = 2.5f;
	public static float ZOMBIE_BULLET_SPEED = 0.15f;
	public static float ZOMBIE_BULLET_DESTRUCT_TIME = 1f;

	public static int SKELETON_HP = 4;
	public static int SKELETON_DAMAGE = 5;
	public static float SKELETON_ATTACK_TIME = 1.0f;
	public static float SKELETON_ATTACK_RANGE = 2f;
	public static float SKELETON_MOVE_SPEED = 7f;
	public static float SKELETON_DELAY_AFTER_ATTACK = 1f;

	public static int WIZARD_HP = 14;
	public static int WIZARD_DAMAGE = 5;
	public static float WIZARD_ATTACK_TIME = 10f;
	public static float WIZARD_ATTACK_RANGE = 13.0f;
	public static float WIZARD_MOVE_SPEED = 3.5f;
	public static float WIZARD_DELAY_AFTER_ATTACK = 3f;

	public static int SUMMON_HP = 2;
	public static int SUMMON_DAMAGE = 3;
	public static float SUMMON_ATTACK_TIME = 1.5f;
	public static float SUMMON_ATTACK_RANGE = 2f;
	public static float SUMMON_MOVE_SPEED = 6f;
	public static float SUMMON_DELAY_AFTER_ATTACK = 1.5f;

	/* ========================================
					FOR LEVELS
	========================================= */
	public static float ZOMBIE_GENERATE_SCHEDULE = 2.5f;

	/* ========================================
					FOR BULLETS
	========================================= */
	public static float BULLET_PISTOL_SPEED = 1f;
	public static int BULLET_PISTOL_DAMAGE = 2;
	public static float BULLET_PISTOL_DESTRUCT_TIME = 0.2f;
	public static float BULLET_PISTOL_ATTACK_SPEED = 0.3f;

	public static float BULLET_SHORTGUN_DAMAGE = 1f;
	public static float BULLET_SHORTGUN_DESTRUCT_TIME = 0.05f;
	public static float BULLET_SHORTGUN_SPEED = 1.5f;
	public static float BULLET_SHORTGUN_ATTACK_SPEED = 0.5f;

	/* ========================================
					FOR PLAYER
	========================================= */
	public static float PLAYER_MOVE_SPEED = 5f;
	public static int PLAYER_HP = 20;
}
