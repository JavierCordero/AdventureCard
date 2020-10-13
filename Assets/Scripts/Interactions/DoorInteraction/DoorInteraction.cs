using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, InteractionInterface
{
    public enum DoorState { Closed, Open }

    public string m_open, m_cosed;
    public Animation m_animation;
    private DoorState m_state = DoorState.Closed;

    public DoorState getDoorState() { return m_state; }

    public void ActionPerformed()
    {
        Animator DoorAnimator = GetComponentInParent<Animator>();
        DoorAnimator.SetBool("OpenDoor", !DoorAnimator.GetBool("OpenDoor"));
    }
}
