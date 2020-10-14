using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject playerEyes;
    public float InteracionDistance = 2;
    public LayerMask OnlyMaskToInteract;

    public GameObject InteractionText;

    [HideInInspector] public bool actionPerformed = false;

    // Start is called before the first frame update
    void Start()
    {
        OnlyMaskToInteract = 1 << OnlyMaskToInteract;
        OnlyMaskToInteract = ~OnlyMaskToInteract;
      
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerEyes.transform.position, playerEyes.transform.forward, out hit, InteracionDistance, OnlyMaskToInteract))
        {
            if (InteractionText && hit.transform.gameObject.GetComponent<InteractionInterface>() != null)
                InteractionText.SetActive(true);

            if(actionPerformed)
                hit.transform.gameObject.GetComponent<InteractionInterface>().ActionPerformed();

        }

        else InteractionText.SetActive(false);

        actionPerformed = false;

    }


}
