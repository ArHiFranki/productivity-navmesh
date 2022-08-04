using UnityEngine;
using Productivity.Movement;
using Productivity.Core;

namespace Productivity.Combat
{
    /// <summary>
    /// Implements combat system mechanics
    /// </summary>
    //[RequireComponent(typeof(Mover))]
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        [SerializeField] private float weaponDamage = 5f;

        private Transform target;
        private Mover myMover;
        private float timeSinceLastAttack = 0;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                myMover.MoveTo(target.position);
            }
            else
            {
                myMover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                timeSinceLastAttack = 0;
                Health healthComponent = target.GetComponent<Health>();
                healthComponent.TakeDamage(weaponDamage);
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
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        /// <summary>
        /// Cancel attack to target
        /// </summary>
        public void Cancel()
        {
            target = null;
        }
    }
}
