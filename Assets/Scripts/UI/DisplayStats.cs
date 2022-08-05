using UnityEngine;
using Productivity.Combat;
using TMPro;

namespace Productivity.UI
{
    public class DisplayStats : MonoBehaviour
    {
        [SerializeField] private Health healthComponent = null;
        [SerializeField] private ScoreKeeper scoreKeeperComponent = null;
        [SerializeField] private TMP_Text healthText = null;
        [SerializeField] private TMP_Text scoreText = null;

        private void Update()
        {
            healthText.text = "Health: " + healthComponent.CurrentHealth;
            scoreText.text = "Score: " + scoreKeeperComponent.Score;
        }
    }
}
