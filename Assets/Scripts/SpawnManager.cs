using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public Transform enemy;
	public Transform enemy2;

	public Transform SpawnPoint;

	public float timeBetweenWaves = 10f;
	private float timeCountDown = 2f;

	private int waveNumber = 0;
	private int boss = 0;

	
	// Update is called once per frame
	void Update () {
		if (timeCountDown <= 0f) {
			StartCoroutine (SpawnWave());
			timeCountDown = timeBetweenWaves;
		}
		timeCountDown -= Time.deltaTime;
	}

	IEnumerator SpawnWave(){
		waveNumber++;
		Debug.Log (waveNumber);

		if (waveNumber % 10 == 0) {
			boss++;
			for (int i = 0; i < boss; i++) {
				SpawnEnemy2 ();
				yield return new WaitForSeconds (1f);
			}
		} else {

			for (int i = 0; i < waveNumber; i++) {
				SpawnEnemy ();
				yield return new WaitForSeconds (1f);
			}
		}
	}

	void SpawnEnemy(){
		Instantiate (enemy, SpawnPoint.position, SpawnPoint.rotation);
	}

	void SpawnEnemy2(){
		Instantiate (enemy2, SpawnPoint.position, SpawnPoint.rotation);
	}
}
