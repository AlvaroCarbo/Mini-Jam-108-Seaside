using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    public class TriggerButton : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int PressedHash = Animator.StringToHash("Pressed");
        
        public delegate void Pressed(bool pressed);
        public event Pressed OnPressed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool(PressedHash, true);
                // GetComponent<AudioSource>().Play();
                // GetComponent<Renderer>().material.color = Color.green;
                OnPressed?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool(PressedHash, false);
                // GetComponent<AudioSource>().Play();
                // GetComponent<Renderer>().material.color = Color.green;
                OnPressed?.Invoke(false);
            }
        }
    }
}