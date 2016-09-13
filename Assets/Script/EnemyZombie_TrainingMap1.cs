using UnityEngine;
using System.Collections;

public class EnemyZombie_TrainingMap1 : MonoBehaviour {

	public float distance;

	Transform target;
	public NavMeshAgent nav;
	public Transform player;
	//Animator controller;
	public float health = 100;
	//ZombieSpawnPointManager game;
	CapsuleCollider capsuleCollider;
    SphereCollider sphereCollider;
	public Animator anim;
	//public float TheDamage = 50;
	RaycastHit hit;
	//public bool isDead = false;
	//public bool isHit = false;
	//public bool isAttack = false;
	public GameObject[] pickups;

    //public float TimetoAttack;
    //float attackTimer;
    //public AudioClip zombieAttackClip;
    //public Text score;
    //public int scoreValue = 10;
    //private int scoring = 1;

    //public GranadaExplode TimeFreeze;
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

//	private vp_PlayerEventHandler PlayerEvents = null;

	private GameObject PlayerReference;
	private PlayerHealthNewChar PlayerScriptReferece;


	//public GameObject indicatePain;

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		capsuleCollider = GetComponent <CapsuleCollider> ();
        sphereCollider = GetComponent<SphereCollider>();
		anim = GetComponent <Animator> ();


//		PlayerEvents = player.transform.GetComponent<vp_PlayerEventHandler> ();

        PlayerReference = GameObject.Find("OVRPlayerController");
        PlayerScriptReferece = PlayerReference.GetComponent<PlayerHealthNewChar>();


        GameManagerGO = GameObject.Find("GameManager");
        ScrManager = GameManagerGO.GetComponent<ScoreManager>();
        //TimeFreeze = TimeFreeze.GetComponent<GranadaExplode>();
    }

	void Start () {

        //PlayerScriptReferece.PlayerIsDead = true;
        //anim.SetBool("PlayerIsDead", true);
        //anim.SetBool("PlayerInRange", false);
        //nav.enabled = false;

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

    public float currentValue;
	public bool canAttack = true;

	// Update is called once per frame
	void Update () {
		       
		distance = Vector3.Distance(transform.position,player.position);

        if (PlayerScriptReferece.PlayerIsDead == true)
            anim.SetBool("PlayerIsDead", true);
        else
            anim.SetBool("PlayerIsDead", false);
		
		if (anim.GetBool("EnemyStillAlive") == true)
		{
			if(canAttack ==  true)
			{
				nav.SetDestination(player.position);
				RotateTowards(player.transform);
				
				if (nav.remainingDistance <= 2)
					anim.SetBool("PlayerInRange", true);
				else if (nav.remainingDistance >= 2)
					anim.SetBool("PlayerInRange", false);
				
				anim.SetFloat("PlayerStillThere", currentValue);
				
				if (anim.GetBool("PlayerInRange") == true)
				{
					currentValue += 0.01f;
					if (currentValue >= 1.1f)
						currentValue = 0;
				}           
				
			}
		}

		//if(distance <= 10)
		//{
		//	canAttack = true;
		//	nav.stoppingDistance = 2;
		//	gameObject.GetComponent<Patrol>().enabled = false;
		//}

    }



	public bool InRange;

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Player"))
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
        if (other.CompareTag("Player"))
            InRange = false;
    }

    private GameObject Player;
    private PlayerHealthNewChar Phealth;
    private float MainDamage = 5;
//	private vp_FPPlayerDamageHandler hp;

   public void Attack()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Phealth = Player.GetComponent<PlayerHealthNewChar>();
        
        if (InRange)
        {
            if (Phealth != null)
            {

                Phealth.remove(MainDamage);
				//PlayerEvents.TakeDamage.Send();
            }

			AudioSource noise = GetComponent<AudioSource>();
			noise.Play();

        }        
    }
    


	public void ApplyDamage(float damage)
	{
		health -= damage;

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


        StartCoroutine(SpawnMedicine());

        CheckWhichZombieIAm();
		Destroy (gameObject, 4f);
		}

    IEnumerator SpawnMedicine ()
    {
        yield return new WaitForSeconds(2);
        int randomDrop = Random.Range(0, 10);
        int randomPickup = Random.Range(0, pickups.Length - 1);
        if (randomDrop < 2)
        {
            //Instantiate(pickups[randomPickup], transform.position + new Vector3(0, 0.25f, 0), Quaternion.Euler(0, 0, 0));
        }
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

//	protected virtual void OnEnable()
//	{
//		if (PlayerEvents != null)
//			PlayerEvents.Unregister (this);
//	}
//
//	protected virtual void OnDisable()
//	{
//		if (PlayerEvents != null)
//			PlayerEvents.Unregister (this);
//	}
//
//	protected virtual void SendMessage()
//	{
//		PlayerEvents.TakeDamage.Send ();
//	}
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
