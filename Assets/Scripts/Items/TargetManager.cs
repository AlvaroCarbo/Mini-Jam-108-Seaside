using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    // [Serializable]
    // public struct Target
    // {
    //     public List<GameObject> targets;
    //     public GameObject coin;
    // Fucking unity inspector is a piece of shit
    // }

    public class TargetManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] targets1;
        [SerializeField] private GameObject[] targets2;
        [SerializeField] private GameObject[] targets3;

        [SerializeField] private GameObject coin1;
        [SerializeField] private GameObject coin2;
        [SerializeField] private GameObject coin3;

        [SerializeField] private int targetsDone1 = 0;
        [SerializeField] private int targetsDone2 = 0;
        [SerializeField] private int targetsDone3 = 0;

        public static TargetManager Instance;

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
            
            coin1.SetActive(false);
            coin2.SetActive(false);
            coin3.SetActive(false);
        }

        public void Increase(int group)
        {
            switch (group)
            {
                case 1:
                    targetsDone1++;
                    if (targetsDone1 == targets1.Length)
                    {
                        coin1.SetActive(true);
                    }

                    break;
                case 2:
                    targetsDone2++;
                    if (targetsDone2 == targets2.Length)
                    {
                        coin2.SetActive(true);
                    }

                    break;
                case 3:
                    targetsDone3++;
                    if (targetsDone3 == targets3.Length)
                    {
                        coin3.SetActive(true);
                    }

                    break;
            }
        }
    }
}