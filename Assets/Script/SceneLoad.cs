using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Change(int sceneNo)
	{
		SceneManager.LoadScene (sceneNo);
		Time.timeScale = 1;
	}
}
