using UnityEngine;

namespace Productivity.Combat
{
    /// <summary>
    /// Implements health mechanic
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] private float currentHealth = 100f;

        private bool isDead = false;

        public bool IsDead => isDead;
        public float CurrentHealth => currentHealth;

        /// <summary>
        /// Reduce bot health by taking damage
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0);

            if (currentHealth == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Set bot health and restore isDead condition
        /// </summary>
        /// <param name="value">healh value</param>
        public void SetHealth(int value)
        {
            currentHealth = value;
            isDead = false;
        }
    }
}
