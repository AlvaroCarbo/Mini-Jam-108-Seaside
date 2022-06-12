using System;
using UnityEngine;

namespace Items
{
    public class TriggerEventTarget : MonoBehaviour
    {
        [SerializeField] private TriggerButton triggerButton;

        private void Awake()
        {
            TriggerEvent(false);
        }

        private void Start()
        {
            triggerButton.OnPressed += TriggerEvent;
        }

        private void TriggerEvent(bool pressed)
        {
            GetComponent<MeshRenderer>().enabled = pressed;
            GetComponent<Collider>().enabled = pressed;
        }

        private void OnDestroy()
        {
            triggerButton.OnPressed -= TriggerEvent;
        }

        private void OnDisable()
        {
            triggerButton.OnPressed -= TriggerEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Arrow")) return;

            triggerButton.OnPressed -= TriggerEvent;
        }
    }
}