using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Productivity.Combat;

namespace Productivity.UI
{
    public class DisplayLeaderboard : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown leaderboardDropdown;

        private void Update()
        {
            UpdateLeaderboard();
        }

        public void UpdateLeaderboard()
        {
            List<string> options = new List<string>();
            ScoreKeeper[] bots = FindObjectsOfType<ScoreKeeper>();
            leaderboardDropdown.ClearOptions();

            for (int i = 0; i < bots.Length; i++)
            {
                string option = bots[i].name + " x " + bots[i].Score;
                options.Add(option);
            }
            options.Sort();

            leaderboardDropdown.AddOptions(options);
            leaderboardDropdown.RefreshShownValue();
        }
    }
}
