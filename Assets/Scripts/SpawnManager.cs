using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public Transform enemy;
	public Transform enemy2;
    public Transform boss;


    public static int EnemiesAlive = 0;

	public Transform SpawnPoint;
    public Vector3 offsetboss;

    public float timeBetweenWaves = 3f;
	private float timeCountDown = 3f;
    public float startTimeGame = 10f;

	private int waveNumber = 0;
	private int bossNumber = 0;
    private int enemyNumber = 0;
    private int enemyNumber2 = 0;


    // Update is called once per frame
    void Update () {
        if (waveNumber < 10)
        {
            if (timeCountDown <= 0f)
            {
                StartCoroutine(SpawnWave());
                timeCountDown = startTimeGame;
                return;
            }

        }
        else {
            if (EnemiesAlive > 0)
            {
                return;
            }
        }

		if (timeCountDown <= 0f) {
			StartCoroutine (SpawnWave());
			timeCountDown = timeBetweenWaves;
            return;
		}
		timeCountDown -= Time.deltaTime;
	}

	IEnumerator SpawnWave(){
		waveNumber++;
		Debug.Log (waveNumber);

		if (waveNumber % 10 == 0) {
			bossNumber++;
			for (int i = 0; i < bossNumber; i++) {
			    SpawnBoss ();
				yield return new WaitForSeconds (10f);
			}
		}

        if (waveNumber % 3 == 0)
        {
            enemyNumber2++;
            for (int i = 0; i < enemyNumber2; i++)
            {
                SpawnEnemy2();
                yield return new WaitForSeconds(5f);
            }
        }
        else
        {
            enemyNumber++;
            for (int i = 0; i < enemyNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2f);
            }
        }
	}

	void SpawnEnemy(){
		Instantiate (enemy, SpawnPoint.position, SpawnPoint.rotation);
        EnemiesAlive++;
	}

	void SpawnEnemy2(){
		Instantiate (enemy2, SpawnPoint.position, SpawnPoint.rotation);
        EnemiesAlive++;
    }

    void SpawnBoss()
    {
        Instantiate(boss, SpawnPoint.position, SpawnPoint.rotation);
        EnemiesAlive++;
    }
}
