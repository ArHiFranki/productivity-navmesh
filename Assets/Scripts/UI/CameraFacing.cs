using UnityEngine;

namespace Productivity.UI
{
    /// <summary>
    /// Implement facing UI to camera mechanic
    /// </summary>
    public class CameraFacing : MonoBehaviour
    {
        private Transform myCamera;

        private void Awake()
        {
            myCamera = Camera.main.transform;
        }

        private void Update()
        {
            transform.forward = myCamera.forward;
        }
    }
}
