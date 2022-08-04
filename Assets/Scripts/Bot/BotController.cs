using UnityEngine;
using Productivity.Movement;
using Productivity.Combat;

namespace Productivity.Bot
{
    /// <summary>
    /// Implements the facade pattern for controlling the bot and the basic logic of the bot's behavior
    /// </summary>
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Fighter))]
    [RequireComponent(typeof(TargetFinder))]
    public class BotController : MonoBehaviour
    {
        private Mover myMover;
        private Fighter myFighter;
        private TargetFinder myTargetFinder;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
            myFighter = GetComponent<Fighter>();
            myTargetFinder = GetComponent<TargetFinder>();
        }

        private void Update()
        {
            if (InteractWithCombat()) return;
            InteractWithMovement();
        }

        private bool InteractWithCombat()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.transform.TryGetComponent(out CombatTarget target))
                {
                    if (myFighter.CanAttack(target))
                    {
                        myFighter.Attack(target);
                        return true;
                    }
                }
            }
            return false;
        }

        private void InteractWithMovement()
        {
            myMover.StartMoveAction(myTargetFinder.FindClosestCombatTargetPosition());
        }
    }
}
