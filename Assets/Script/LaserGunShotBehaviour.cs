using UnityEngine;
using System.Collections;

public class LaserGunShotBehaviour : MonoBehaviour {

    public float BulletSpeed;
    	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * BulletSpeed;
	}
}
