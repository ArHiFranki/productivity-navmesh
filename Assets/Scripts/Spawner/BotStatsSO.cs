using UnityEngine;

namespace Productivity.Spawner
{
    /// <summary>
    /// Bot stats configuration template
    /// </summary>
    [CreateAssetMenu(menuName = "Bot Stats", fileName = "New Bot Stats")]
    public class BotStatsSO : ScriptableObject
    {
        [SerializeField] private float moveSpeedMin;
        [SerializeField] private float moveSpeedMax;
        [SerializeField] private int damageMin;
        [SerializeField] private int damageMax;
        [SerializeField] private int healthMin;
        [SerializeField] private int healthMax;

        public float MoveSpeedMin => moveSpeedMin;
        public float MoveSpeedMax => moveSpeedMax;
        public int DamageMin => damageMin;
        public int DamageMax => damageMax;
        public int HealthMin => healthMin;
        public int HealthMax => healthMax;
    }
}
