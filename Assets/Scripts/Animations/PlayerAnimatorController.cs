using Enums;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorController : MonoBehaviour
    {
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBool(Enums.AnimatorParameters parameter, bool value) =>
            _animator.SetBool(parameter.ToString(), value);
        
        public void SetInt(Enums.AnimatorParameters parameter, int value) =>
            _animator.SetInteger(parameter.ToString(), value);

        public void SetFloat(Enums.AnimatorParameters parameter, float value) =>
            _animator.SetFloat(parameter.ToString(), value);

        public void SetTrigger(Enums.AnimatorParameters parameter) =>
            _animator.SetTrigger(parameter.ToString());
        
        public void PlayTargetAnimation(Enums.AnimatorParameters parameter) =>
            _animator.Play(parameter.ToString());
        
        public void PlayTargetAnimation(AnimatorStates targetAnimation, bool isInteracting, int indexLayer)
        {
            _animator.applyRootMotion = isInteracting;
            SetBool(AnimatorParameters.Interact, isInteracting);
            _animator.CrossFade(targetAnimation.ToString(), 0.2f, indexLayer);
        }
    }
}