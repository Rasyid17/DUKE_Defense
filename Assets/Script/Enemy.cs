using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float distance;
	RaycastHit hit;
	Transform target;
	public NavMeshAgent nav;
	public Transform device;
	public float health = 100;
	CapsuleCollider capsuleCollider;
	SphereCollider sphereCollider;
	public Animator anim;
	public GameObject[] pickups;

	private GameObject GameManagerGO;
	private ScoreManager ScrManager;
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

	public float ZombieADamage = 2.5f;
	public float ZombieA1Damage = 2.5f;
	public float ZombieA2Damage = 2.5f;

	public float ZombieBDamage = 5.0f;
	public float ZombieB1Damage = 5.0f;
	public float ZombieB2Damage = 5.0f;

	public float ZombieCDamage = 10.0f;
	public float ZombieC1Damage = 10.0f;
	public float ZombieC2Damage = 10.0f;

	public float ZombieDDamage = 7.5f;
	public float ZombieD1Damage = 7.5f;
	public float ZombieD2Damage = 7.5f;

	private GameObject DeviceReference;
	private float MainDamage;
	public bool InRange;
	public float currentValue;
	public bool canAttack = true;


	void Awake()
	{
		nav = GetComponent <NavMeshAgent> ();
		device = GameObject.FindGameObjectWithTag("Need2Destroy").transform;
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

		if (DeviceReference.GetComponent<DeviceHealth>().PlayerIsDead == true)
			anim.SetBool("PlayerIsDead", true);
		else
			anim.SetBool("PlayerIsDead", false);

		if (anim.GetBool ("EnemyStillAlive") == true) {
			if (canAttack == true) {
				nav.SetDestination (device.position);
				RotateTowards (device.transform);

				if (nav.remainingDistance <= 2)
					anim.SetBool ("PlayerInRange", true);
				else if (nav.remainingDistance >= 2)
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
		//if (TimeFreeze.AreaOfEffectLongevity > 0)//Check duration of TimeFreeze
		//{
		//     if (TimeFreeze.gameObject.activeInHierarchy == true)//Check if TimeFreeze is still active
		//        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0.0f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);//Prevents zombies from turning when in radius of active TimeFreeze
		//}
		//else
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); //Rotate like normal
	}
}
