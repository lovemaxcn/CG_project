using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUtils{
	public static float calculateDistance(Vector3 from, Vector3 to)
	{
		return Mathf.Sqrt(Mathf.Pow(to.x - from.x, 2) + Mathf.Pow(to.z - from.z, 2));
	}

	public static float calculatePlayerRotate (float x, float y, int wid, int hei)
	{
		float rad, deg;
		x = x - wid / 2;
		y = y - hei / 2;
		rad = Mathf.Asin (y / Mathf.Sqrt(x * x + y * y));
		deg = rad * Mathf.Rad2Deg;
		if (x < 0) {
			deg += 180;
		} else {
			deg = -deg;
		}
		return deg + 90;
	}

	public static float calculateZombieRotate(float px, float pz, float zx, float zz){
		float rad, deg;
		rad = Mathf.Asin ((px - zx) / (Mathf.Sqrt(Mathf.Pow(px - zx, 2) + Mathf.Pow(pz - zz, 2))));
		deg = rad * Mathf.Rad2Deg;
		if (zz > pz) {
			deg = 180 - deg;
		}
		return deg;
	}

	public static int getMonsterDamageByTag(string tag){
		if (tag.Equals (Constant.TAG_SKELETON_SWORD))
			return Config.SKELETON_DAMAGE;
		else if(tag.Equals (Constant.TAG_SUMMON_SWORD))
			return Config.SUMMON_DAMAGE;
		else if (tag.Equals (Constant.TAG_ZOMBIE_BULLET))
			return Config.ZOMBIE_DAMAGE;
		else
			return 0;
	}

	public static int getMonsterWithPercent (int percent){
		if (percent > Config.GENERATE_PERCENT_SKELETON + Config.GENERATE_PERCENT_ZOMBIE)
			return 3;
		if (percent > Config.GENERATE_PERCENT_SKELETON)
			return 2;
		return 1;
	}

	public static float getAttackSpeedForGun(int gun){
		float ret;
		switch (gun) {
		case 1:
			ret = Config.BULLET_PISTOL_ATTACK_SPEED;
			break;
		case 2:
			ret = Config.BULLET_SHORTGUN_ATTACK_SPEED;
			break;
		default:
			ret = 0;
			break;
		}
		return ret;
	}
}
