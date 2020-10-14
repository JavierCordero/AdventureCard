using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, InteractionInterface
{
    public enum DoorState { Closed, Open }

    public string m_open, m_closed;
    public Animation m_animation;
    [HideInInspector]
    public DoorState m_state = DoorState.Open;
    public DoorState getDoorState() { return m_state; }

    public float timeToInteractwithDoor = 1;
    private float m_remainingTime = 1;

    private bool canInteract = true;

    private void Update()
    {
        // No hacemos nada mientras la puerta se está abriendo o cerrando
        m_remainingTime = Mathf.Max(m_remainingTime - Time.deltaTime, 0.0f);
        if (m_remainingTime > 0.0f)
        {
            canInteract = false;
            return;
        }

        else canInteract = true;
    }


    public void ActionPerformed()
    {
        if (canInteract)
        {
            m_remainingTime = timeToInteractwithDoor;

            if (m_state != DoorState.Open)
            {
                m_animation.Play(m_open);
                m_state = DoorState.Open;
            }
            else if (m_state != DoorState.Closed)
            {
                m_animation.Play(m_closed);

                m_state = DoorState.Closed;
            }
        }
    }
}
