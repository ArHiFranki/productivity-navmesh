using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Productivity.Combat;
using Productivity.Movement;

namespace Productivity.Spawner
{
    /// <summary>
    /// Implements spawn bots mechanic
    /// </summary>
    public class Spawner : ObjectPool
    {
        [SerializeField] private BotStatsSO botStatsConfig;
        [SerializeField] private int botsToSpawn;
        [SerializeField] private List<Transform> spawnPoints;

        private void Start()
        {
            InitPool();
            StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
            for (int i = 0; i < botsToSpawn; i++)
            {
                TryCreateObjectFromPool(botPool);
            }
            yield return null;
        }

        private void TryCreateObjectFromPool(List<GameObject> objectPool)
        {
            if (TryGetObject(objectPool, out GameObject objectFromPool))
            {
                SetObject(objectFromPool, GenerateSpawnPointPosition());
            }
        }

        private void TryCreateObjectFromPool(List<GameObject> objectPool, Vector3 position)
        {
            if (TryGetObject(objectPool, out GameObject objectFromPool))
            {
                SetObject(objectFromPool, position);
            }
        }

        private Vector3 GenerateSpawnPointPosition()
        {           
            int index = Random.Range(0, spawnPoints.Count);
            Transform currentPoint = spawnPoints[index];

            if (spawnPoints.Contains(currentPoint))
            {
                spawnPoints.Remove(currentPoint);
            }

            return currentPoint.transform.position;
        }

        private void SetObject(GameObject spawnObject, Vector3 spawnPoint)
        {
            int randomHealthValue = Random.Range(botStatsConfig.HealthMin, botStatsConfig.HealthMax);
            spawnObject.GetComponent<Health>().SetHealth(randomHealthValue);

            int randomDamageValue = Random.Range(botStatsConfig.DamageMin, botStatsConfig.DamageMax);
            spawnObject.GetComponent<Fighter>().SetDamage(randomDamageValue);

            float randomMoveSpeedValue = Random.Range(botStatsConfig.MoveSpeedMin, botStatsConfig.MoveSpeedMax);
            spawnObject.GetComponent<Mover>().SetMoveSpeed(randomMoveSpeedValue);

            spawnObject.GetComponent<ScoreKeeper>().ResetScore();
            spawnObject.SetActive(true);
            spawnObject.transform.position = spawnPoint;
        }

        /// <summary>
        /// Spawn bot in a given position
        /// </summary>
        /// <param name="spawnPosition">position to spawn</param>
        public void SpawnBotByClick(Vector3 spawnPosition)
        {
            TryCreateObjectFromPool(botPool, spawnPosition);
        }
    }
}
