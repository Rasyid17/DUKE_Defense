﻿using UnityEngine;
using System.Collections;

public class DeviceHealth : MonoBehaviour {

	public float startingHealth = 100f;
	public float currentHealth;
	public float MaxHealth = 100f;
	public float MinHealth = 0f;

	public GameObject HP;
	private CustomText customPref;

	private GameObject[] ZombiesAll;
	public NavMeshAgent[] ZombieNavMesh;

	public bool PlayerIsDead = false;

	public GameObject hurtfx;

	void Awake () {
	
		ZombiesAll = GameObject.FindGameObjectsWithTag("Enemy");

		ZombieNavMesh = new NavMeshAgent[ZombiesAll.Length];
		for (int i = 0; i < ZombiesAll.Length; i++)
		{
			ZombieNavMesh[i] = ZombiesAll[i].GetComponent<NavMeshAgent>();
		}

	}

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () {
	
		if(currentHealth >= 100)
		{
			currentHealth = MaxHealth;
		}

		//=====================================================
		if (currentHealth <= 0.0f) 
		{
			currentHealth = MinHealth;
			PlayerIsDead = true;
			gameObject.GetComponent<DeviceHealth>().enabled = false;
		}
		//======================================================
		if(currentHealth <= 40)
		{
			
		}
		else
		{
			
		}

	}

}
