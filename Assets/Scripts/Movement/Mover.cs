using UnityEngine;
using UnityEngine.AI;
using Productivity.Core;

namespace Productivity.Movement
{
    /// <summary>
    /// Implements movement mechanics
    /// </summary>
    //[RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour, IAction
    {
        private NavMeshAgent myNavMeshAgent;

        private void Awake()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
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
        public void Cancel()
        {
            myNavMeshAgent.isStopped = true;
        }
    }
}
