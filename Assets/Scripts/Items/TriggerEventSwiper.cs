using UnityEngine;

namespace Items
{
    public class TriggerEventSwiper : MonoBehaviour
    {
        [SerializeField] private TriggerButton triggerButton;

        private Animator _animator;
        
        private static readonly int ActionHash = Animator.StringToHash("Action");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            triggerButton.OnPressed += Trigger;
        }

        private void Trigger(bool pressed)
        {
            _animator.SetFloat(ActionHash, pressed ? 1 : 0);
        }

        private void OnDestroy()
        {
            triggerButton.OnPressed -= Trigger;
        }

        private void OnDisable()
        {
            triggerButton.OnPressed -= Trigger;
        }
    }
}