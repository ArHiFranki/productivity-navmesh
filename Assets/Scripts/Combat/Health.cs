using UnityEngine;

namespace Productivity.Combat
{
    /// <summary>
    /// Implements health mechanic
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health = 100f;

        private bool isDead = false;

        public bool IsDead => isDead;

        /// <summary>
        /// Reduce bot health by taking damage
        /// </summary>
        /// <param name="damage">Damage amount</param>
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            Debug.Log(health);

            if (health == 0)
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
    }
}
