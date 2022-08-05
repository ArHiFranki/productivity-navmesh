using UnityEngine;

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

        private void SpawnToCursor()
        {
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
