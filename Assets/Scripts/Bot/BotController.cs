using UnityEngine;
using Productivity.Movement;

namespace Productivity.Bot
{
    /// <summary>
    /// Implements the facade pattern for controlling the bot and the basic logic of the bot's behavior
    /// </summary>
    [RequireComponent(typeof(Mover))]
    public class BotController : MonoBehaviour
    {
        private Mover myMover;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                myMover.MoveTo(hit.point);
            }
        }
    }
}
