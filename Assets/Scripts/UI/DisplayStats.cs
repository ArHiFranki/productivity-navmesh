using UnityEngine;
using Productivity.Combat;
using TMPro;

namespace Productivity.UI
{
    public class DisplayStats : MonoBehaviour
    {
        [SerializeField] private Health healthComponent = null;
        [SerializeField] private TMP_Text healthText = null;

        private void Update()
        {
            healthText.text = "Health: " + healthComponent.CurrentHealth;
        }
    }
}
