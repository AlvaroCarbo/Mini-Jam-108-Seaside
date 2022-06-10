using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineVirtualDynamic : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    private void Awake()
    {
        // Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
        // if (brain != null)
        // {
        //     
        // }
        
        _virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}