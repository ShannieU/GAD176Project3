using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private SpawnPoint[] allPointsInGame;

    [SerializeField] List<SpawnPoint> spawnPoints;
    [SerializeField] List<GameObject> enemies;

    private void Start()
    {
        allPointsInGame = FindObjectsOfType<SpawnPoint>();

        spawnPoints.AddRange(allPointsInGame);

        if(spawnPoints == null)
        {
            Debug.Log("No point to spawn");
        }

        for(int i = 0; i < spawnPoints.Count; i++)
        {
            Debug.Log("owo");
        }
    }

}
