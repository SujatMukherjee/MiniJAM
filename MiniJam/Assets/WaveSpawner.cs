using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    List<Wave> waves;

    [SerializeField]
    float TimeBetweenWaves = 70f;

    private void Awake()
    {
        foreach (Wave wave in waves)
        {
            wave.gameObject.SetActive(false);
        }

    }

    private void Start()
    {
        SpawnWave();
    }

    private void Update()
    {
        if (timer >= TimeBetweenWaves) SpawnWave();
        timer += Time.deltaTime;
    }


    float timer = 0;
    int waveNumber = 0;
    void SpawnWave()
    {
        timer = 0;
        waves[waveNumber].gameObject.SetActive(true);
        waveNumber++;

    }


}
