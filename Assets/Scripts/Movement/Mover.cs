using UnityEngine;
using UnityEngine.AI;
using Productivity.Combat;

namespace Productivity.Movement
{
    /// <summary>
    /// Implements movement mechanics
    /// </summary>
    //[RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        private NavMeshAgent myNavMeshAgent;
        private Fighter myFighter;

        private void Awake()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
            myFighter = GetComponent<Fighter>();
        }

        public void StartMoveAction(Vector3 destination)
        {
            myFighter.CancelFighting();
            MoveTo(destination);
        }

        /// <summary>
        /// Moves to a given destination
        /// </summary>
        /// <param name="destination">Vector3 to set the destination point</param>
        public void MoveTo(Vector3 destination)
        {
            myNavMeshAgent.isStopped = false;
            myNavMeshAgent.destination = destination;
        }

        /// <summary>
        /// Stop moving object
        /// </summary>
        public void Stop()
        {
            myNavMeshAgent.isStopped = true;
        }
    }
}
