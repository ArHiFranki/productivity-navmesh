using UnityEngine;
using Productivity.Movement;

namespace Productivity.Combat
{
    /// <summary>
    /// Implements combat system mechanics
    /// </summary>
    //[RequireComponent(typeof(Mover))]
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        private Transform target;
        private Mover myMover;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                myMover.MoveTo(target.position);
            }
            else
            {
                myMover.Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        /// <summary>
        /// Attack the target
        /// </summary>
        /// <param name="combatTarget">Object which have an CombatTarget component</param>
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        /// <summary>
        /// Cancel attack to target
        /// </summary>
        public void CancelFighting()
        {
            target = null;
        }
    }
}
