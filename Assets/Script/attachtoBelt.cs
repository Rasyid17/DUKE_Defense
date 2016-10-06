	using UnityEngine;
using System.Collections;
using VRTK;

public class attachtoBelt : MonoBehaviour {

	public GameObject holster;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = holster.transform.position;
		gameObject.transform.rotation = holster.transform.rotation;
	}
}
