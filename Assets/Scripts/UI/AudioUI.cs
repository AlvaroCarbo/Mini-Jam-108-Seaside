using Inputs;
using UnityEngine;

namespace UI
{
    public class AudioUI : MonoBehaviour
    {
        [SerializeField] private AudioClip uiTextClip;

        private void Start() => InputHandler.Instance.OnEscapePress += PlayUISound;

        private void OnDestroy() => InputHandler.Instance.OnEscapePress -= PlayUISound;

        private void OnDisable() => InputHandler.Instance.OnEscapePress -= PlayUISound;
        private void PlayUISound() => AudioManager.Instance.EffectsSource.PlayOneShot(uiTextClip);
    }
}