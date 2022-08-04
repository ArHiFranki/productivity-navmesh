using UnityEngine;

namespace Productivity.Bot
{
    /// <summary>
    /// Bot stats configuration template
    /// </summary>
    [CreateAssetMenu(menuName = "Bot Stats", fileName = "New Bot Stats")]
    public class BotStatsSO : ScriptableObject
    {
        [SerializeField] private int moveSpeedMin;
        [SerializeField] private int moveSpeedMax;
        [SerializeField] private int damageMin;
        [SerializeField] private int damageMax;
        [SerializeField] private int healthMin;
        [SerializeField] private int healthMax;

        public int MoveSpeedMin => moveSpeedMin;
        public int MoveSpeedMax => moveSpeedMax;
        public int DamageMin => damageMin;
        public int DamageMax => damageMax;
        public int HealthMin => healthMin;
        public int HealthMax => healthMax;
    }
}
