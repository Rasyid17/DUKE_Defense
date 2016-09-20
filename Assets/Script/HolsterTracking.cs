using UnityEngine;
using System.Collections;

public class HolsterTracking : MonoBehaviour {

	[SerializeField]
	GameObject leftHolster, rightHolster;
	[SerializeField]
	float offsetX, offsetY, offsetZ;

	// Update is called once per frame
	void Update () {

		float faceAngle = transform.rotation.eulerAngles.y;

		// make both holsters follow headset; x-offset is distance from centre
		leftHolster.GetComponent<Transform>().position = transform.position +
			new Vector3 (
				(-Mathf.Abs(offsetX) * Mathf.Cos(-faceAngle * Mathf.Deg2Rad)) + (Mathf.Abs(offsetZ) * Mathf.Sin(-faceAngle * Mathf.Deg2Rad)),
				offsetY,
				(-Mathf.Abs(offsetX) * Mathf.Sin(-faceAngle * Mathf.Deg2Rad)) + (Mathf.Abs(offsetZ) * Mathf.Cos(-faceAngle * Mathf.Deg2Rad))
			);
		rightHolster.GetComponent<Transform>().position = transform.position +
			new Vector3 (
				(Mathf.Abs(offsetX) * Mathf.Cos(-faceAngle * Mathf.Deg2Rad)) + (Mathf.Abs(offsetZ) * Mathf.Sin(-faceAngle * Mathf.Deg2Rad)),
				offsetY,
				(Mathf.Abs(offsetX) * Mathf.Sin(-faceAngle * Mathf.Deg2Rad)) + (Mathf.Abs(offsetZ) * Mathf.Cos(-faceAngle * Mathf.Deg2Rad))
			);
		
		// rotate by y axis to follow headset rotation
		leftHolster.GetComponent<Transform> ().rotation = Quaternion.AngleAxis(faceAngle, Vector3.up);
		rightHolster.GetComponent<Transform> ().rotation = Quaternion.AngleAxis(faceAngle, Vector3.up); 
	}
}
