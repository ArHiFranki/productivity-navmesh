using UnityEngine;
using UnityEngine.AI;

namespace Productivity.Movement
{
    /// <summary>
    /// Implements movement mechanics
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        private NavMeshAgent myNavMeshAgent;

        private void Awake()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// Moves to a given destination
        /// </summary>
        /// <param name="destination">Vector3 to set the destination point</param>
        public void MoveTo(Vector3 destination)
        {
            myNavMeshAgent.destination = destination;
        }
    }
}
