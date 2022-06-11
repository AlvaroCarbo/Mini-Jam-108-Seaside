using System;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    public class TriggerButton : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Pressed = Animator.StringToHash("Pressed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool(Pressed, true);
                
                // GetComponent<AudioSource>().Play();
                // GetComponent<Renderer>().material.color = Color.green;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _animator.SetBool(Pressed, false);

                // GetComponent<AudioSource>().Play();
                // GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}