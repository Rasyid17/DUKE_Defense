using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    private GameObject HealthNumGO;
    private CustomText HealthNum;

    private GameObject PlayerGO;
    private PlayerHealthNewChar PHealth;

    public float DisplayHealth;

    void Start ()
    {
        HealthNumGO = GameObject.Find("HealthNum");
        HealthNum = HealthNumGO.GetComponent<CustomText>();

        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        PHealth = PlayerGO.GetComponent<PlayerHealthNewChar>();
    }

    void Update ()
    {
        HealthNum.text = PHealth.currentHealth.ToString();
        DisplayHealth = PHealth.currentHealth;
    }
}
