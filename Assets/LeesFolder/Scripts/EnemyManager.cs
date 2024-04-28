using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeesStuff
{
    public class EnemyManager : MonoBehaviour
    {
        private SpawnPoint[] allPointsInGame;

        [SerializeField] List<SpawnPoint> spawnPoints;
        [SerializeField] List<GameObject> aliveEnemies;
        [SerializeField] GameObject enemyRunnerPrefab, enemyShooterPrefab;


        private void Start()
        {
            allPointsInGame = FindObjectsOfType<SpawnPoint>();

            spawnPoints.AddRange(allPointsInGame);

            if (spawnPoints == null)
            {
                Debug.Log("No point to spawn");
            }
            FindLocationToSpawn();
        }

        private void Update()
        {
            //SpawnEnemies();
            if(aliveEnemies.Count == 0)
            {
                //Call move to next location event. 
            }
        }

        private void FindLocationToSpawn()
        {
            SpawnPoint spawnHere = spawnPoints[0];
            int nextPointToSpawn = 9999;

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                if (spawnPoints[i].order <= nextPointToSpawn)
                {
                    spawnHere = spawnPoints[i];
                    nextPointToSpawn = spawnPoints[i].order;
                }
            }
            //Debug.Log("Will spawn at " + spawnHere);
            spawnPoints.Remove(spawnHere);
            SpawnEnemies(spawnHere);
        }

        private void SpawnEnemies(SpawnPoint spawn)
        {
            for (int i = 0; i < spawn.enemyCount; i++)
            {
                //check the amount of covers
                if (i < spawn.covers.Count)
                {
                    //spawn the shooters first and give them the cover
                    GameObject thisLad = Instantiate(enemyShooterPrefab, spawn.mineLocation);
                    EnemyShooter thisLadsScript = thisLad.GetComponent<EnemyShooter>();
                    thisLadsScript.mineCover = spawn.covers[i];

                    aliveEnemies.Add(thisLad);
                }
                //then spawn the runners
                else
                {
                    GameObject thisOtherLad = Instantiate(enemyRunnerPrefab, spawn.mineLocation);
                    aliveEnemies.Add(thisOtherLad);
                }
            }
        }

        public void KillEnemy(GameObject target)
        {
            if (aliveEnemies.Contains(target))
            {
                aliveEnemies.Remove(target);
            }
            Destroy(target);
        }
    }
}