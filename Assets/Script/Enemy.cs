using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Header("Info")]
	public float distance;
	RaycastHit hit;
	Transform target;
	NavMeshAgent nav;
	Transform device;
	public float health = 100;
	CapsuleCollider capsuleCollider;
	SphereCollider sphereCollider;
	Animator anim;

	private GameObject GameManagerGO;
	private ScoreManager ScrManager;

	[Header("Type of enemy")]
	public bool IAmZombieA;
	public bool IAmZombieA1;
	public bool IAmZombieA2;

	public bool IAmZombieB;
	public bool IAmZombieB1;
	public bool IAmZombieB2;

	public bool IAmZombieC;
	public bool IAmZombieC1;
	public bool IAmZombieC2;

	public bool IAmZombieD;
	public bool IAmZombieD1;
	public bool IAmZombieD2;

	private float ZombieADamage = 2f;
	private float ZombieA1Damage = 2f;
	private float ZombieA2Damage = 2f;

	private float ZombieBDamage = 5.0f;
	private float ZombieB1Damage = 5.0f;
	private float ZombieB2Damage = 5.0f;

	private float ZombieCDamage = 10.0f;
	private float ZombieC1Damage = 10.0f;
	private float ZombieC2Damage = 10.0f;

	private float ZombieDDamage = 8f;
	private float ZombieD1Damage = 8f;
	private float ZombieD2Damage = 8f;

	private GameObject DeviceReference;
	private float MainDamage;

	[Header("Current state")]
	public bool InRange;
	float currentValue;
	public bool canAttack = true;

	private float enemydamage;


	void Awake()
	{
		nav = GetComponent <NavMeshAgent> ();
		device = GameObject.FindGameObjectWithTag("Device").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
		sphereCollider = GetComponent<SphereCollider>();
		anim = GetComponent <Animator> ();

		DeviceReference = GameObject.Find ("Device");
		GameManagerGO = GameObject.Find ("GameManager");
		ScrManager = GameManagerGO.GetComponent<ScoreManager> ();
	}

	// Use this for initialization
	void Start () {
	
		if (IAmZombieA)
			MainDamage = ZombieADamage;
		if (IAmZombieA1)
			MainDamage = ZombieA1Damage;
		if (IAmZombieA2)
			MainDamage = ZombieA2Damage;

		if (IAmZombieB)
			MainDamage = ZombieBDamage;
		if (IAmZombieB1)
			MainDamage = ZombieB1Damage;
		if (IAmZombieB2)
			MainDamage = ZombieB2Damage;

		if (IAmZombieC)
			MainDamage = ZombieCDamage;
		if (IAmZombieC1)
			MainDamage = ZombieC1Damage;
		if (IAmZombieC2)
			MainDamage = ZombieC2Damage;

		if (IAmZombieD)
			MainDamage = ZombieDDamage;
		if (IAmZombieD1)
			MainDamage = ZombieD1Damage;
		if (IAmZombieD2)
			MainDamage = ZombieD2Damage;
	}
	
	// Update is called once per frame
	void Update () {
	
		distance = Vector3.Distance(transform.position,device.position);

//		print (nav.remainingDistance);

		if (DeviceReference.GetComponent<DeviceHealth>().PlayerIsDead == true)
			anim.SetBool("PlayerIsDead", true);
		else
			anim.SetBool("PlayerIsDead", false);

		if (anim.GetBool ("EnemyStillAlive") == true) {
			if (canAttack == true) {
				nav.SetDestination (device.position);
				RotateTowards (device.transform);

				if (nav.remainingDistance <= 3)
					anim.SetBool ("PlayerInRange", true);
				else if (nav.remainingDistance >= 3)
					anim.SetBool ("PlayerInRange", false);

				anim.SetFloat ("PlayerStillThere", currentValue);

				if (anim.GetBool ("PlayerInRange") == true) {
					currentValue += 0.01f;
					if (currentValue >= 1.1f)
						currentValue = 0;
				}    
			}
		}
	}

	private void RotateTowards (Transform target) 
	{
		Vector3 direction = (target.position - transform.position).normalized;
		direction.y = 0.0f;//Prevents zombies from tilting forwards/backwards when player is facing them
		Quaternion lookRotation = Quaternion.LookRotation(direction);
	
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); //Rotate like normal
	}

	public void Attack()
	{
		
		if (InRange)
		{
			DeviceReference.GetComponent<DeviceHealth>().remove(MainDamage);

			AudioSource noise = GetComponent<AudioSource>();
			noise.Play();

//			print ("nomnom");

		}        
	}

	public void ApplyDamage(float amount)
	{
		health -= amount;

		if (IAmZombieA || IAmZombieA1 || IAmZombieA2 || IAmZombieC || IAmZombieC1 || IAmZombieC2 || IAmZombieB || IAmZombieB1 || IAmZombieB2 || IAmZombieD || IAmZombieD1 || IAmZombieD2) {
			anim.SetBool ("EnemyGotHit", true);
			StartCoroutine (DamageCoolDown ());

		} 

		if (health <= 0)
			Death ();
	}


	IEnumerator DamageCoolDown ()
	{
		yield return new WaitForSeconds(0.2f);
		anim.SetBool("EnemyGotHit", false);
	}

	void Death ()
	{

		nav.Stop ();
		capsuleCollider.enabled = false;
		sphereCollider.enabled = false;

		if (IAmZombieA || IAmZombieA1 || IAmZombieA2 || IAmZombieC || IAmZombieC1 || IAmZombieC2 || IAmZombieB || IAmZombieB1 || IAmZombieB2 || IAmZombieD || IAmZombieD1 || IAmZombieD2) {
			anim.SetBool("EnemyStillAlive", false);

		}


		CheckWhichZombieIAm();
		Destroy (gameObject, 4f);
	}

	void CheckWhichZombieIAm ()
	{
		if (IAmZombieA)
			ScrManager.KilledZombieA();
		if (IAmZombieA1)
			ScrManager.KilledZombieA1();
		if (IAmZombieA2)
			ScrManager.KilledZombieA2();

		if (IAmZombieB)
			ScrManager.KilledZombieB();
		if (IAmZombieB1)
			ScrManager.KilledZombieB1();
		if (IAmZombieB2)
			ScrManager.KilledZombieB2();

		if (IAmZombieC)
			ScrManager.KilledZombieC();
		if (IAmZombieC1)
			ScrManager.KilledZombieC1();
		if (IAmZombieC2)
			ScrManager.KilledZombieC2();

		if (IAmZombieD)
			ScrManager.KilledZombieD();
		if (IAmZombieD1)
			ScrManager.KilledZombieD1();
		if (IAmZombieD2)
			ScrManager.KilledZombieD2();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Device"))
			InRange = true;

		if (other.CompareTag ("Dead"))
		{
			InRange = false;
			anim.SetBool("PlayerIsDead", true);
			canAttack = false;
			nav.enabled = false;
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.CompareTag("Device"))
			InRange = false;
	}


}
