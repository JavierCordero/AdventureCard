using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, InteractionInterface
{
    public void ActionPerformed()
    {
        Animator DoorAnimator = GetComponentInParent<Animator>();
        DoorAnimator.SetBool("OpenDoor", !DoorAnimator.GetBool("OpenDoor"));
    }
}
