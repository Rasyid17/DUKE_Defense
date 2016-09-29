using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    private GameObject HealthNumGO;
    private TextMesh HealthNum;

    private GameObject PlayerGO;
	private DeviceHealth PHealth;

    public float DisplayHealth;

    void Start ()
    {
        HealthNumGO = GameObject.Find("HealthNum");
        HealthNum = HealthNumGO.GetComponent<TextMesh>();

        PlayerGO = GameObject.FindGameObjectWithTag("Device");
		PHealth = PlayerGO.GetComponent<DeviceHealth>();
    }

    void Update ()
    {
        HealthNum.text = PHealth.currentHealth.ToString();
        DisplayHealth = PHealth.currentHealth;
    }
}
