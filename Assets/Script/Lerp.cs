using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {

	public GameObject Player;

	private Vector3 StartPos;
	private Vector3 EndPos;
	public float GoDistance = 0.1f;
	public float speed = 0.1f;
	private float currentLerpTime = 0f;

	private bool keyhit = false;

	private bool doOnce = true;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		StartPos = Player.transform.localPosition;
		
		if (Player.GetComponent<PlayerHealthNewChar>().currentHealth == 0f) {
		
			keyhit = true;

//			print(EndPos);
			 


		}

		if (keyhit == true) {

			if(doOnce == true)
			{
				EndPos = Player.transform.localPosition + Vector3.down * GoDistance;
				doOnce = false;
			}


			currentLerpTime += Time.deltaTime;
			if(currentLerpTime >= speed)
			{
				currentLerpTime = speed;
			}

			float perc = currentLerpTime/speed;
			Player.transform.position = Vector3.Lerp(StartPos, EndPos,perc);
//			print (perc);

			if (perc >= 1)
			{
				keyhit = false;
			}
		}
	}
	
}
