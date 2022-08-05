using UnityEngine;

namespace Productivity.Combat
{
    /// <summary>
    /// Implement bot score keeping system
    /// </summary>
    public class ScoreKeeper : MonoBehaviour
    {
        private int score = 0;

        public int Score => score;

        /// <summary>
        /// Increase score by 1
        /// </summary>
        public void AddScore()
        {
            score++;
        }

        /// <summary>
        /// Set score to 0
        /// </summary>
        public void ResetScore()
        {
            score = 0;
        }
    }
}
