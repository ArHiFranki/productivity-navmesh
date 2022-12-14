using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Productivity.UI;
using Productivity.Combat;

namespace Productivity.Spawner
{
    /// <summary>
    /// Implement Object Pooling
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject botContainer;
        [SerializeField] private GameObject botPrefab;
        [SerializeField] private int botPoolCapacity;

        [SerializeField] protected DisplayLeaderboard leaderboard;

        protected List<GameObject> botPool = new List<GameObject>();

        private void Initialize(GameObject prefab, List<GameObject> pool, GameObject container, int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, container.transform);
                spawned.SetActive(false);
                spawned.GetComponent<Health>().InitLeaderboard(leaderboard);
                pool.Add(spawned);
            }
        }

        protected void InitPool()
        {
            Initialize(botPrefab, botPool, botContainer, botPoolCapacity);
        }

        protected bool TryGetObject(List<GameObject> pool, out GameObject result)
        {
            result = pool.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }
    }
}
