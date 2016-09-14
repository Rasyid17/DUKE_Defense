using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public GameObject PauseCanvasGO;
    public GameObject InGameCanvasGO;
    public AudioListener CamAudioListener;
    public string levelName;

    public enum PauseState
    {
        Pause,
        UnPause

    };

    public PauseState CurrentPauseState;

    void Start ()
    {
        CurrentPauseState = PauseState.UnPause;
    }

	void Update () {
        switch (CurrentPauseState)
        {
            case PauseState.UnPause:
                //print("Unpausing");
                if (Input.GetButtonDown("Submit"))
                    ToPause();
                break;
            case PauseState.Pause:
                //print("Pause");
                if ((Input.GetButtonDown("Submit")) || (Input.GetButtonDown("Fire1")))
                    ToUnPause();
                if (Input.GetButtonDown("Cancel"))
                    SceneManager.LoadScene(0);
                break;
        }       
	}

    public void ToPause () {
        this.CurrentPauseState = PauseState.Pause;
        PauseCanvasGO.SetActive(true);
        InGameCanvasGO.SetActive(false);
        Time.timeScale = 0;
        CamAudioListener.enabled = false;
    }
    public void ToUnPause () {
        this.CurrentPauseState = PauseState.UnPause;
        PauseCanvasGO.SetActive(false);
        InGameCanvasGO.SetActive(true);
        Time.timeScale = 1;
        CamAudioListener.enabled = true;
    }
 }
