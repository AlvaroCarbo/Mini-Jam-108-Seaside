using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class SwiperManager : MonoBehaviour
    {
        public static SwiperManager Instance;
        
        [SerializeField] private List<GameObject> swiperMode1;
        [SerializeField] private List<GameObject> swiperMode2;
        
        private static readonly int ActionHash = Animator.StringToHash("Action");

        private PlayerMovement _playerMovement;

        private bool _toggle;

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

        private void Start()
        {
            var player = GameObject.FindWithTag("Player");
            
            if (player == null) return;
            
            _playerMovement = player.GetComponent<PlayerMovement>();
            
            if (_playerMovement != null)
            {
                _playerMovement.OnPressed += OnSwipe;
            }
            
            _toggle = true;
            
            OnSwipe();
        }

        private void OnSwipe()
        {
            _toggle = !_toggle;
            
            foreach (var sw in swiperMode1)
            {
                sw.GetComponent<Animator>().SetFloat(ActionHash, _toggle ? 1 : 0);
            }
            
            foreach (var sw in swiperMode2)
            {
                sw.GetComponent<Animator>().SetFloat(ActionHash, !_toggle ? 1 : 0);
            }
        }

        private void OnDestroy()
            {
                _playerMovement.OnPressed -= OnSwipe;
            }

            private void OnDisable()
            {
                _playerMovement.OnPressed -= OnSwipe;
            }
    }
}