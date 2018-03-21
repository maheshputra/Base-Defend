using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public Transform enemy;

	public Transform SpawnPoint;

	public float timeBetweenWaves = 5f;
	private float timeCountDown = 2f;

	private int waveNumber = 0;
	
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

		for(int i=0;i < waveNumber;i++){
			SpawnEnemy();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy(){
		Instantiate (enemy, SpawnPoint.position, SpawnPoint.rotation);
	}
}
