using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> wavesconfig;
    [SerializeField] bool looping;
    private bool endOfWaves = false;
    int startingWaveIndex = 0;
    // Start is called before the first frame update

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        endOfWaves = true;

        
    }

    private void Update()
    {
        if (FindObjectsOfType<Enemy>().Length <= 0 && endOfWaves)
        {
            FindObjectOfType<SceneLoader>().LoadStartMenuScene();
        }
    }




    private IEnumerator SpawnAllWaves()
    {
        for ( int waveIndex = startingWaveIndex; waveIndex < wavesconfig.Count ; waveIndex++ )
        {
            var currentWave = wavesconfig[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, waveConfig.GetEnemyPrefab().transform.rotation);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBeteewneSpawns());
        }
    }
}
