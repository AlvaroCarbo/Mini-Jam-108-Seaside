using UnityEngine;

namespace Cameras
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public Camera mainCamera;

        public Transform cameraTransform;

        private void Start()
        {
            mainCamera = Camera.main;
            
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
        }
    }
}