using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private GameObject HealthNumGO;
    private Text HealthNum;
	private GameObject HPBar;

    private GameObject PlayerGO;
	private DeviceHealth PHealth;

    public float DisplayHealth;

    void Start ()
    {
        HealthNumGO = GameObject.Find("HealthNum");
        HealthNum = HealthNumGO.GetComponent<Text>();

		HPBar = GameObject.Find ("HealthBar");

        PlayerGO = GameObject.FindGameObjectWithTag("Device");
		PHealth = PlayerGO.GetComponent<DeviceHealth>();
    }

    void Update ()
    {
        HealthNum.text = PHealth.currentHealth.ToString();
        DisplayHealth = PHealth.currentHealth;
		HPBar.GetComponent<Slider>().value = PHealth.currentHealth;
    }
}
