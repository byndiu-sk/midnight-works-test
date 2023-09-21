using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEditor.Build;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;

    [SerializeField]
    private float defaultSensitivity;
    [SerializeField]
    private float aimSensitivity;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.Sensitivity = aimSensitivity;
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.Sensitivity = defaultSensitivity;
        }
    }
}
