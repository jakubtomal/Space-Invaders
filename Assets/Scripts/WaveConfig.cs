using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    public GameObject[] pathPrefab;
    private int pathNumber = 0;
    [SerializeField] float timesBetweeneSpawns = 0.5f;
    [SerializeField] int numberOfEnemies;
    [Range(0,10)][SerializeField] float moveSpeed;


    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab[pathNumber].transform)
        {
            waveWaypoints.Add(child);
        }

        
        return waveWaypoints;
    }

    public float GetTimeBeteewneSpawns() { return timesBetweeneSpawns; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public void SetPathNumber(int pathNumber)
    {
        this.pathNumber = pathNumber;
    }

}

