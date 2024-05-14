using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5.5f;

    private float countDown = 2f;

    [SerializeField]
    private Text waveCountDownTimer;

    [SerializeField]
    private Text WaveText;

    private int waveNumber = 0;

	void Update () {
		if (countDown <= 0.2f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        waveCountDownTimer.text = Mathf.Round(countDown).ToString();
	}
    IEnumerator spawnWave ()
    {
        waveNumber++;
        WaveText.text = "[Wave|" + waveNumber + "]";
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
