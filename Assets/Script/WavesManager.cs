using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour {

	public enum SpawnState
	{
		SPAWNING, WAITING, COUNTING
	}

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	private GameObject waveNum;
	private TextMesh waveNumGo;

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	public float waveCountdown;

	private float searchCountdown = 1f;

	public SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start () {
	
		if(spawnPoints.Length == 0)
		{
			Debug.LogError ("No spawn points reference");
		}

		waveCountdown = timeBetweenWaves;
		waveNum = GameObject.Find ("WaveNum");
		waveNumGo = waveNum.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(state == SpawnState.WAITING)
		{
			if(!EnemyIsAlive())
			{
				WaveCompleted ();
			}
			else
			{
				return;
			}

//			waveNumGo.text = name.ToString();
		}

		if(waveCountdown <= 0)
		{
			if(state != SpawnState.SPAWNING)
			{
				StartCoroutine (SpawnWave (waves [nextWave]));
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted()
	{
		Debug.Log ("Wave Completed");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if(nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			Debug.Log ("All waves complete");
		}
		else
		{
			nextWave++;
		}

	}

	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;

		if(searchCountdown <= 0f)
		{
			if(GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log ("Spawning Wave:" + _wave.name);

		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy (_wave.enemy);

			yield return new WaitForSeconds (1f / _wave.rate);
		}

		state = SpawnState.WAITING;
		waveNumGo.text = _wave.name.ToString ();
		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{
		Transform _sp = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate (_enemy, _sp.position, _sp.rotation);
		Debug.Log ("Spawning Enemy" + _enemy.name);
	}
}
