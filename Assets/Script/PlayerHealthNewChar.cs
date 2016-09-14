using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthNewChar : MonoBehaviour {
	
	public float startingHealth = 100f;
	public float currentHealth;
	public float MaxHealth = 100f;
    public float MinHealth = 0f;

	private GameObject HealthAnimGO;
	private Animation HealthAnim;
	
	private GameObject HealthPlusGO;
	private CustomText HealthPlus;
	private Animation HealthPlusAnim;

	public GameObject HP;
	private CustomText customPref;

	private GameObject PlayerReference;
	private PlayerHealthNewChar PlayerDmgHandler;// the component is disabled when playing
	private PlayerHealthNewChar ComponentReference;//didnt work

	private GameObject[] ZombiesAll;
	public NavMeshAgent[] ZombieNavMesh;

	public bool PlayerIsDead = false;

	private GameObject CharAnimGO;
	private Animation CharAnim;

//	protected vp_FPPlayerEventHandler eventplayer = null;
//	private vp_PlayerDamageHandler plydmg;

	public GameObject Waktu;
	public GameObject CenterEyeAcnhor;
	public GameObject hurtfx;

	public float AntidoteHealAmount = 20f;
	public float AntidoteAmount = 3f;

	public GameObject Rank;
	public GameObject RankGet;
	public GameObject Restart;
	public GameObject QuitGame;

	public GameObject body;

	public AudioClip DeathSFX;
	//public GameObject AudioSourceReference;
	public GameObject SyringeAudioSourceReference;
	private bool Counter;//for DoOnce

	void Awake() {


		Time.timeScale = 1;

		hurtfx.SetActive (false);

		currentHealth = startingHealth;

		UnityEngine.VR.VRSettings.enabled = true;

		HealthAnimGO = GameObject.Find("HealthNum");
		HealthAnim = HealthAnimGO.GetComponent<Animation>();
		
		HealthPlusGO = GameObject.Find("HealthNumPlus");
		HealthPlus = HealthPlusGO.GetComponent<CustomText>();
		HealthPlusAnim = HealthPlusGO.GetComponent<Animation>();
		
		HealthPlus.text = "";

		ZombiesAll = GameObject.FindGameObjectsWithTag("Zombie");
		
		ZombieNavMesh = new NavMeshAgent[ZombiesAll.Length];
		for (int i = 0; i < ZombiesAll.Length; i++)
		{
			ZombieNavMesh[i] = ZombiesAll[i].GetComponent<NavMeshAgent>();
		}

		body = GameObject.Find("HeartBeatSFX");
		body.GetComponent<AudioSource>().enabled = false;
	}


	void Start()
	{	
		PlayerReference = GameObject.Find("OVRPlayerController");

		if(PlayerReference == null)
		{
			PlayerReference = GameObject.Find("PlayerOVRLobby");
		}

		PlayerDmgHandler = PlayerReference.GetComponent<PlayerHealthNewChar>();
		customPref = HP.GetComponent<CustomText>();
		gameObject.GetComponent<Lerp>().enabled = false;
		Rank.GetComponent<CustomText>().enabled = false;
		RankGet.GetComponent<CustomText>().enabled = false;
		QuitGame.SetActive (false);
		Restart.SetActive (false);
	}

	void Update() 
	{
        if(currentHealth >= 100)
        {
            currentHealth = MaxHealth;
        }

        //PlayerDmgHandler.CurrentHealth = currentHealth/10;

		if (Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.J)) 
		{
			if(AntidoteAmount > 0)
			{
				if(currentHealth == MaxHealth)
				{
					print ("You are already at full health!");
				}
				else
				{
					SyringeAudioSourceReference.GetComponent<AudioSource>().Play ();
					if(currentHealth + AntidoteHealAmount > MaxHealth)
					{
						currentHealth = MaxHealth;
						AntidoteAmount -= 1;
					}
					else
					{
						currentHealth += AntidoteHealAmount;
						AntidoteAmount -= 1;
					}
				}
			}
		}
		//=====================================================
		if (currentHealth <= 0.0f) 
		{
			if(!Counter)
			{
				Counter = true;
				/*AudioSourceReference.GetComponent<AudioSource>().clip = DeathSFX;
				AudioSourceReference.GetComponent<AudioSource>().loop =  false;
				AudioSourceReference.GetComponent<AudioSource>().Play ();*/
			}
            currentHealth = MinHealth;
			PlayerIsDead = true;
			Waktu.GetComponent<TimeManager>().enabled = false;
//			PlayerDmgHandler.Die();
//			CenterEyeAcnhor.GetComponent<VideoGlitches.VideoGlitchNoiseDigital>().enabled = true;
//			gameObject.GetComponent<vp_FPPlayerEventHandler>().enabled= false;
			gameObject.GetComponent<PlayerHealthNewChar>().enabled = false;
			gameObject.GetComponent<Lerp>().enabled = true;
			Rank.GetComponent<CustomText>().enabled = true;
			RankGet.GetComponent<CustomText>().enabled = true;
			Restart.SetActive (true);
			QuitGame.SetActive (true);
		}
		//======================================================
		if(currentHealth <= 40)
		{
			body.GetComponent<AudioSource>().enabled = true;
		}
		else
		{
			body.GetComponent<AudioSource>().enabled = false;
		}

	}

	public void remove(float amount) { //animation when damaged
        if (currentHealth != MinHealth)
        {
            currentHealth -= amount;
        }
        /*
		HealthAnim.Play("HealthNumAnim");

		StartCoroutine(HealthNumPlusVisibility());
		HealthPlus.text = "- " + amount.ToString() + " points";
		HealthPlusAnim.Play("HealthNumPlusAnim");
        */

		hurtfx.SetActive (true);
		StartCoroutine (Hurt());
	}
	
	public void add(float amount){ //animation when healed

            currentHealth += amount;
        /*
		HealthAnim.Play("HealthNumAnim");
		
		StartCoroutine(HealthNumPlusVisibility());
		HealthPlus.text = "+ " + amount.ToString() + " points";
		HealthPlusAnim.Play("HealthNumPlusAnim");
        */
	}


	IEnumerator HealthNumPlusVisibility()
	{
		HealthPlus.enabled = true;
		yield return new WaitForSeconds(0.5f);
		HealthPlus.enabled = false;
	}

	IEnumerator Hurt()

	{
		yield return new WaitForSeconds (0.5f);
		hurtfx.SetActive (false);
	}
	
	
}