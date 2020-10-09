using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTargetSelector : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera_;
    [SerializeField] private Transform targetCameraTransform_;

    private CinemachineBrain cameraBrain_;

    private PlayerMovement playerMovement_;

    void Start()
    {
        cameraBrain_ = mainCamera_.GetComponent<CinemachineBrain>();
        playerMovement_ = GetComponent<PlayerMovement>();
    }


    public void EnableTargetSelector()
    {
        playerMovement_.DisablePlayerMovement();
        cameraBrain_.enabled = false;
        mainCamera_.transform.position = targetCameraTransform_.position;
    }

    public void DisableTargetSelector()
    {
        playerMovement_.EnablePlayerMovement();
        cameraBrain_.enabled = true;
    }

}
