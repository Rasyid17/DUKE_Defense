using UnityEngine;
using System.Collections;

public class ShotHIT : MonoBehaviour {

	public float damageZombie;
	public GameObject bloodSplat;

	void Start()
	{
//		Debug.Log ("mothafucka");
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Enemy") 
		{
			hit.gameObject.GetComponent<Enemy> ().ApplyDamage (damageZombie);
			GameObject blood = GameObject.Instantiate(bloodSplat, transform.position, transform.rotation) as GameObject;
			GameObject.Destroy(blood, 0.5f);
			//Debug.Log ("HIT LA");
		}

		if ((hit.gameObject.tag != "PlayerNoCollide") && (hit.gameObject.tag != "Bullet") && (hit.gameObject.tag != "Device")) {
			Destroy(gameObject);
		}
	}
}
