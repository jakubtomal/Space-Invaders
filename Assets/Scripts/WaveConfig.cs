using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timesBetweeneSpawns = 0.5f;
    [SerializeField] float timesRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies;
    [Range(0,10)][SerializeField] float moveSpeed;


    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        
        return waveWaypoints;
    }

    public float GetTimeBeteewneSpawns() { return timesBetweeneSpawns; }

    public float GetRandomFactor() { return timesRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

}

