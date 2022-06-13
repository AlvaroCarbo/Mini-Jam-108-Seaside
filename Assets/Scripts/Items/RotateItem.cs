using UnityEngine;

namespace Items
{
    public class RotateItem : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationSpeed;

        private void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        // private void OnTriggerEnter(Collider other)
        // {
        //     Debug.Log(other + " entered " + gameObject);
        // }
    }
}
