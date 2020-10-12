using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTargetSelector : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera_, secondCamera_, playerRepresentation_, killingCamera_;
    [SerializeField] private Transform targetCameraTransform_;

    private CameraMovement cameraMovement_;

    private PlayerMovement playerMovement_;

    private bool TargetSelectorModeEnabled = false;

    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private float maxSelectorTime = 2;

    private float currentSelectorTime = 0;

    public GameObject selectorObject;

    [SerializeField]
    private float timeReduction = 0.5f;

    [SerializeField]
    private float maxSelectorDistance = 20;

    [SerializeField]
    private float killEnemiesTime = 0.2f;

    private WaitForSeconds killingEnemiesTimeWait;

    public Animator playerAnimator;

    private PlayerAnimationController animationController;

    private bool killingEnemies = false;

    void Start()
    {
        cameraMovement_ = secondCamera_.transform.GetChild(0).GetComponent<CameraMovement>();

        playerMovement_ = GetComponent<PlayerMovement>();

        selectorObject.SetActive(false);
        killingEnemiesTimeWait = new WaitForSeconds(killEnemiesTime);

        animationController = FindObjectOfType<PlayerAnimationController>();

    }

    private void Update()
    {
        if (TargetSelectorModeEnabled)
        {

            currentSelectorTime += Time.deltaTime;

            if (currentSelectorTime >= maxSelectorTime)
                DisableTargetSelector();


            RaycastHit hit;

            Ray r = new Ray(secondCamera_.transform.GetChild(1).position, secondCamera_.transform.GetChild(1).forward * maxSelectorDistance);

            bool rayCollision = Physics.Raycast(r, out hit, 100, 1 << LayerMask.NameToLayer("Enemies"));

            if (rayCollision)
            {
                if (!targets.Contains(hit.transform.gameObject))
                {
                    targets.Add(hit.transform.gameObject);
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }

            }

            if (Physics.Raycast(r, out hit))
            {
                selectorObject.SetActive(true);
                selectorObject.transform.position = hit.point;
            }

            else selectorObject.SetActive(false);

            //else
            //{
            //    selectorObject.transform.position = Vector3.Scale(secondCamera_.transform.GetChild(1).position, secondCamera_.transform.GetChild(1).forward * maxSelectorDistance);

            //}
        }

        if (killingEnemies)
        {

            Vector3 targetDirection = playerRepresentation_.transform.position - mainCamera_.transform.position;

            float singleStep = 10 * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(mainCamera_.transform.forward, targetDirection, singleStep, 0.0f);

            mainCamera_.transform.rotation = Quaternion.LookRotation(newDirection);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Debug.DrawRay(secondCamera_.transform.GetChild(1).position, secondCamera_.transform.GetChild(1).forward * maxSelectorDistance, Color.red);
    //}

    public void EnableTargetSelector()
    {
        Time.timeScale = timeReduction;

        playerMovement_.DisablePlayerMovement();
        
        //cameraBrain_.enabled = false;
        
        mainCamera_.SetActive(false);
        secondCamera_.SetActive(true);
        cameraMovement_.TimeCameraReduction = 1 + timeReduction;
        TargetSelectorModeEnabled = true;
        //mainCamera_.transform.position = targetCameraTransform_.position;
    }

    public void DisableTargetSelector()
    {
        
        TargetSelectorModeEnabled = false;
        selectorObject.SetActive(false);

        if (targets.Count > 0)
            KillAllEnemies();

        else ContinueGame();

        
        //cameraBrain_.enabled = true;
    }

    private void ContinueGame()
    {
        mainCamera_.SetActive(true);
        secondCamera_.SetActive(false);
        killingCamera_.SetActive(false);

        Time.timeScale = 1;
        currentSelectorTime = 0;
        playerMovement_.EnablePlayerMovement();    
    }

    private void KillAllEnemies()
    {
        mainCamera_.SetActive(false);
        secondCamera_.SetActive(false);
        killingCamera_.SetActive(true);

        StartCoroutine(KillAllEnemiesRoutine());
    }

    IEnumerator KillAllEnemiesRoutine()
    {
        //playerRepresentation_.SetActive(false);

        Vector3 originalPos = animationController.transform.parent.gameObject.transform.position;

        //mainCamera_.transform.GetChild(1).GetComponent<CinemachineBrain>().enabled = false;
        killingEnemies = true;

        GameObject player = animationController.transform.parent.gameObject;

        while (targets.Count > 0)
        {
            animationController.DisableAll();
            animationController.EnableAtack(1+ Random.Range(0, 3));

            player.transform.position = targets[0].transform.GetChild(0).position;

            var lookPos = -targets[0].transform.position - player.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            player.transform.rotation = rotation;// Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);

            Destroy(targets[0], 0.4f);
            targets.RemoveAt(0);
            yield return killingEnemiesTimeWait;
           
        }

        killingEnemies = false;

        mainCamera_.SetActive(true);
        killingCamera_.SetActive(false);

        //mainCamera_.transform.GetChild(1).GetComponent<CinemachineBrain>().enabled = true;
        animationController.transform.parent.gameObject.transform.position = originalPos;

        animationController.EnableAtack(0);
        animationController.EnableIdle();
        //playerRepresentation_.SetActive(true);
        ContinueGame();

    }


}
