using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider))]
    public class TargetDetector : MonoBehaviour
    {
        [SerializeField] private int GroupID = 0;
        [SerializeField] private Color hitColor;
        [SerializeField] private bool isHit = false;

        private void OnTriggerEnter(Collider other)
        {
            if (isHit) return;

            if (!other.gameObject.CompareTag("Arrow")) return;

            var meshRenderer = GetComponent<MeshRenderer>();

            meshRenderer.materials[1].color = hitColor;

            TargetManager.Instance.Increase(GroupID);
            
            isHit = true;
        }
    }
}