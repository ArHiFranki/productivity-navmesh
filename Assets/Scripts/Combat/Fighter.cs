using UnityEngine;
using Productivity.Movement;
using Productivity.Core;

namespace Productivity.Combat
{
    /// <summary>
    /// Implements combat system mechanics
    /// </summary>
    [RequireComponent(typeof(Mover))]
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        [SerializeField] private int damage = 5;
        [SerializeField] private int damageIncrement = 2;

        private Health target;
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
            if (target.IsDead) return;

            if (!GetIsInRange())
            {
                myMover.MoveTo(target.transform.position);
            }
            else
            {
                myMover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (target == null) return;

            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                timeSinceLastAttack = 0;
                target.TakeDamage(gameObject, damage);
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackRange;
        }

        /// <summary>
        /// Determines whether it is possible to attack the target
        /// </summary>
        /// <param name="combatTarget">Object which have an CombatTarget component</param>
        /// <returns>return true if target can be attacked</returns>
        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead;
        }

        /// <summary>
        /// Attack the target
        /// </summary>
        /// <param name="combatTarget">Object which have an CombatTarget component</param>
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        /// <summary>
        /// Cancel attack to target
        /// </summary>
        public void Cancel()
        {
            target = null;
        }

        /// <summary>
        /// Set bot damage
        /// </summary>
        /// <param name="value">Damage value</param>
        public void SetDamage(int value)
        {
            damage = value;
        }

        /// <summary>
        /// Increase damage by damageIncrement after kill another bot
        /// </summary>
        public void IncreaseDamage()
        {
            damage += damageIncrement;
        }
    }
}
