using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    public float TimeLeft;
    public string levelName;

    private GameObject TimeNumGO;
    private CustomText TimeNum;

    void Start ()
    {
        TimeLeft = 180;

        TimeNumGO = GameObject.Find("TimeNum");
        //TimeNum = TimeNumGO.GetComponent<CustomText>();
    }

    void Update ()
    {
        TimeLeft -= Time.deltaTime;

        //TimeNum.text = TimeLeft.ToString();

        int minutes = Mathf.FloorToInt(TimeLeft / 60F);
        int seconds = Mathf.FloorToInt(TimeLeft - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        //TimeNum.text = niceTime;

//		print (TimeLeft);

		if (TimeLeft <= 0) 
		{
			//SceneManager.LoadScene(levelName);
		}

    }
}
