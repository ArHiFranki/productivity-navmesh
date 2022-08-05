using UnityEngine;
using UnityEngine.EventSystems;

namespace Productivity.Spawner
{
    [RequireComponent(typeof(Spawner))]
    public class ClickToSpawn : MonoBehaviour
    {
        private Spawner mySpawner;

        private void Awake()
        {
            mySpawner = GetComponent<Spawner>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnToCursor();
            }
        }

        public void SpawnToCursor()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.TryGetComponent(out Ground ground))
                {
                    mySpawner.SpawnBotByClick(hit.point);
                }
            }
        }
    }
}
