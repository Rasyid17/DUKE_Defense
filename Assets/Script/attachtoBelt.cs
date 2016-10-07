	using UnityEngine;
using System.Collections;
using VRTK;

public class attachtoBelt : MonoBehaviour {

	public GameObject holster;
	public bool isGrab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(!isGrab)
		{
			gameObject.transform.position = holster.transform.position;
			gameObject.transform.rotation = holster.transform.rotation;
		}

		else
		{
			
		}

	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Untagged")
		{
//			Debug.Log ("alright");
			isGrab = true;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if(hit.gameObject.tag == "Untagged")
		{
			isGrab = false;
		}
	}
}
