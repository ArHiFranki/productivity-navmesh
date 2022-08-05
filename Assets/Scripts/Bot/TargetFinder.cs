using UnityEngine;
using Productivity.Combat;
using UnityEngine.AI;

namespace Productivity.Bot
{
    /// <summary>
    /// Implements target finding system with using NavMesh
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class TargetFinder : MonoBehaviour
    {
        private NavMeshAgent myAgent;

        private void Awake()
        {
            myAgent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            myAgent.enabled = false;
        }

        /// <summary>
        /// Find closest target avaliable for combat
        /// </summary>
        /// <returns>Vector3 closest target position</returns>
        public Vector3 FindClosestCombatTargetPosition()
        {
            myAgent.enabled = true;
            CombatTarget closestCombatTarget = null;
            float closestTargetDistance = float.MaxValue;
            NavMeshPath path = new NavMeshPath();

            CombatTarget[] targets = FindObjectsOfType<CombatTarget>();

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == null || targets[i].transform.position == this.transform.position)
                {
                    continue;
                }

                if (NavMesh.CalculatePath(transform.position, targets[i].transform.position, myAgent.areaMask, path))
                {
                    float distance = Vector3.Distance(transform.position, path.corners[0]);

                    for (int j = 1; j < path.corners.Length; j++)
                    {
                        distance += Vector3.Distance(path.corners[j-1], path.corners[j]);
                    }

                    if (distance < closestTargetDistance)
                    {
                        closestTargetDistance = distance;
                        closestCombatTarget = targets[i];
                    }
                }
            }

            if (closestCombatTarget != null)
            {
                return closestCombatTarget.transform.position;
            }
            return transform.position;
        }
    }
}
