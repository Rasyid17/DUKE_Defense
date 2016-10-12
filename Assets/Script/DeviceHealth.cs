using UnityEngine;
using System.Collections;

public class DeviceHealth : MonoBehaviour {

	public float startingHealth = 100f;
	public float currentHealth;
	public float MaxHealth = 100f;
	public float MinHealth = 0f;

	public GameObject burn1;
	public GameObject burn2;
	public GameObject burn3;

	public AudioSource explodeSFX;

//	public GameObject HP;
	private CustomText customPref;

	private GameObject[] ZombiesAll;
	public NavMeshAgent[] ZombieNavMesh;

	public bool PlayerIsDead = false;

//	public GameObject hurtfx;

	void Awake () {
	
		currentHealth = startingHealth;

		ZombiesAll = GameObject.FindGameObjectsWithTag("Enemy");

		ZombieNavMesh = new NavMeshAgent[ZombiesAll.Length];
		for (int i = 0; i < ZombiesAll.Length; i++)
		{
			ZombieNavMesh[i] = ZombiesAll[i].GetComponent<NavMeshAgent>();
		}

	}

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () {
	
		if(currentHealth >= 100)
		{
			currentHealth = MaxHealth;
		}

		if(currentHealth == 70)
		{
			burn1.SetActive (true);
		}

		if(currentHealth == 30)
		{
			burn2.SetActive (true);
		}

		if(currentHealth == 15)
		{
			burn3.SetActive (true);
		}


		//=====================================================
		if (currentHealth <= 0.0f) 
		{
			currentHealth = MinHealth;
			PlayerIsDead = true;
			gameObject.GetComponent<DeviceHealth>().enabled = false;
			Time.timeScale = 0;
			explodeSFX.Play ();
			return;
		}

	}

	public void remove(float amount) { //animation when damaged
		if (currentHealth != MinHealth)
		{
			currentHealth -= amount;
		}

//		hurtfx.SetActive (true);
		StartCoroutine (Hurt());
	}

	IEnumerator Hurt()

	{
		yield return new WaitForSeconds (0.5f);
//		hurtfx.SetActive (false);
	}

}
