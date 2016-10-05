using UnityEngine;
using System.Collections;

public class ShotHIT : MonoBehaviour {

	public float damageZombie;

	void Start()
	{
//		Debug.Log ("mothafucka");
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Enemy") 
		{
			hit.gameObject.GetComponent<Enemy> ().ApplyDamage (damageZombie);
			//Debug.Log ("HIT LA");
		}

		if ((hit.gameObject.tag != "PlayerNoCollide") && (hit.gameObject.tag != "Bullet") && (hit.gameObject.tag != "Device")) {
			Destroy(gameObject);
		}
	}
}
