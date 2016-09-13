using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public float ZombieAScore = 10.0f;
	public float ZombieA1Score = 10.0f;
	public float ZombieA2Score = 10.0f;
   
	public float ZombieBScore = 25.0f;
	public float ZombieB1Score = 25.0f;
	public float ZombieB2Score = 25.0f;
   
	public float ZombieCScore = 35.0f;
	public float ZombieC1Score = 35.0f;
	public float ZombieC2Score = 35.0f;

	public float ZombieDScore = 20.0f;
	public float ZombieD1Score = 20.0f;
	public float ZombieD2Score = 20.0f;

	public float DynamiteScore = 100.0f;

    public float CurrentScore;
    public float DynamiteCount;
    public string Rank;

    private GameObject ScoreNumGO;
    private CustomText ScoreNum;
    private Animation ScoreAnim;

    private GameObject ScorePlusGO;
    private CustomText ScorePlus;
    private Animation ScorePlusAnim;

    private GameObject DynamiteNumGO;
    private CustomText PortalNum;
    private Animation DynamiteAnim;

    private GameObject DynamitPlusGO;
    private CustomText DynamitePlus;
    private Animation DynamitePlusAnim;

    public GameObject RankNumGO;
    private CustomText RankNum;


    void Start()
    {
        ScoreNumGO = GameObject.Find("ScoreNum");
        ScoreNum = ScoreNumGO.GetComponent<CustomText>();
        ScoreAnim = ScoreNumGO.GetComponent<Animation>();

        ScorePlusGO = GameObject.Find("ScoreNumPlus");
        ScorePlus = ScorePlusGO.GetComponent<CustomText>();
        ScorePlusAnim = ScorePlusGO.GetComponent<Animation>();

        DynamiteNumGO = GameObject.Find("DynamiteNum");
        PortalNum = DynamiteNumGO.GetComponent<CustomText>();
        DynamiteAnim = DynamiteNumGO.GetComponent<Animation>();

        DynamitPlusGO = GameObject.Find("DynamiteNumPlus");
        DynamitePlus = DynamitPlusGO.GetComponent<CustomText>();
        DynamitePlusAnim = DynamitPlusGO.GetComponent<Animation>();

        RankNumGO = GameObject.Find("RankNum");
        RankNum = RankNumGO.GetComponent<CustomText>();

        ScorePlus.text = "";
        DynamitePlus.text = "";
               
        CurrentScore = 0;
        DynamiteCount = 0;
        Rank = "";
    }

    void Update()
    {
        ScoreNum.text = CurrentScore.ToString();
        PortalNum.text = DynamiteCount.ToString();
        RankNum.text = Rank;

        if (CurrentScore <= 40)
            Rank = "F";
        if ((CurrentScore >= 41) && (CurrentScore <= 80))
            Rank = "D";
        if ((CurrentScore >= 81) && (CurrentScore <= 150))
            Rank = "C";
        if ((CurrentScore >= 151) && (CurrentScore <= 250))
            Rank = "B";
        if ((CurrentScore >= 251) && (CurrentScore <= 380))
            Rank = "A";
        if (CurrentScore >= 381) 
            Rank = "S";
    }

    public void KilledZombieA ()
    {
        CurrentScore += ZombieAScore;
        //ScoreAnim.Play("ScoreNumAnim");

        //StartCoroutine(ScoreNumPlusVisibility());
        //ScorePlus.text = "+ " + ZombieAScore.ToString() + " point";
        //ScorePlusAnim.Play("ScoreNumPlusAnim");
    }

	public void KilledZombieA1 ()
	{
		CurrentScore += ZombieA1Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieA1Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieA2 ()
	{
		CurrentScore += ZombieA2Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieA2Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

    public void KilledZombieB ()
    {
        CurrentScore += ZombieBScore;
        //ScoreAnim.Play("ScoreNumAnim");

        //StartCoroutine(ScoreNumPlusVisibility());
        //ScorePlus.text = "+ " + ZombieBScore.ToString() + " point";
        //ScorePlusAnim.Play("ScoreNumPlusAnim");
    }

	public void KilledZombieB1 ()
	{
		CurrentScore += ZombieB1Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieB1Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieB2 ()
	{
		CurrentScore += ZombieB2Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieB2Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

    public void KilledZombieC ()
    {
        CurrentScore += ZombieCScore;
        //ScoreAnim.Play("ScoreNumAnim");

        //StartCoroutine(ScoreNumPlusVisibility());
        //ScorePlus.text = "+ " + ZombieCScore.ToString() + " point";
        //ScorePlusAnim.Play("ScoreNumPlusAnim");
    }

	public void KilledZombieC1 ()
	{
		CurrentScore += ZombieC1Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieC1Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieC2 ()
	{
		CurrentScore += ZombieC2Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieC2Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieD ()
	{
		CurrentScore += ZombieDScore;
		//ScoreAnim.Play("ScoreNumAnim");
		
		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieDScore.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieD1 ()
	{
		CurrentScore += ZombieDScore;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieD1Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

	public void KilledZombieD2 ()
	{
		CurrentScore += ZombieD2Score;
		//ScoreAnim.Play("ScoreNumAnim");

		//StartCoroutine(ScoreNumPlusVisibility());
		//ScorePlus.text = "+ " + ZombieD2Score.ToString() + " point";
		//ScorePlusAnim.Play("ScoreNumPlusAnim");
	}

    public void GetDynamite ()
    {
        CurrentScore += DynamiteScore;
        DynamiteCount = 1;
        //ScoreAnim.Play("ScoreNumAnim");
        //DynamiteAnim.Play("DynamiteNumAnim");

        //StartCoroutine(ScoreNumPlusVisibility());
        //ScorePlus.text = "+ " + DynamiteScore.ToString() + " point";
        //ScorePlusAnim.Play("ScoreNumPlusAnim");

        //StartCoroutine(DynamiteNumPlusVisibility());
        //DynamitePlus.text = "+ " + DynamiteCount.ToString() + " points";
        //DynamitePlusAnim.Play("DynamiteNumPlusAnim");
    }

    


    IEnumerator ScoreNumPlusVisibility ()
    {
        ScorePlus.enabled = true;
        yield return new WaitForSeconds(0.5f);
        ScorePlus.enabled = false;
    }

    IEnumerator DynamiteNumPlusVisibility ()
    {
        DynamitePlus.enabled = true;
        yield return new WaitForSeconds(0.5f);
        DynamitePlus.enabled = false;
    }

    

}
