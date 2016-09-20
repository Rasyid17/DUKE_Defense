using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public GameObject fireExplosion;
	public GameObject bloodSplatter;
	public AudioSource slice;
	float damageZombie;

	public bool LaserGun;
	public bool LaserRifle;
	public bool Sword;

	void Start()
	{
		if(LaserGun)
			damageZombie = 10;
		else if(LaserRifle)
			damageZombie = 15;
		else if(Sword)
			damageZombie = 25;
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Zombie")
		{
			if(Sword)
            {
                slice.GetComponent<AudioSource>().Play();
            }

            hit.gameObject.GetComponent<Enemy>().ApplyDamage(damageZombie);
            //hit.gameObject.GetComponent<EnemyZombie_Final>().ApplyDamage(damageZombie);
            GameObject blood = GameObject.Instantiate(bloodSplatter, transform.position, transform.rotation) as GameObject;
			GameObject.Destroy(blood, 1f);
			//Debug.Log("blood splatting");
		}
		else
		{
			if(!Sword)
			{
				GameObject smoke = GameObject.Instantiate(fireExplosion, transform.position, fireExplosion.transform.rotation) as GameObject;
				GameObject.Destroy(smoke, 2f);
				//Debug.Log("colliding");
			}
		}
	}

	void OnTriggerExit(Collider hit)
	{
		//print("out of collider");
        if(!Sword)
		Destroy(this);
	}
}
