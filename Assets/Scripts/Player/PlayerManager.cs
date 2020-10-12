using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float playerHP_;
    private bool playerInvencible_ = false;
    public bool readyToPlay_ = true;

    public void DamagePlayer(float dmg)
    {
        if (!playerInvencible_)
        {
            playerHP_ -= dmg;

            if (playerHP_ <= 0)
                KillPlayer();
        }
    }

    private void KillPlayer()
    {
        readyToPlay_ = false;
    }

    public void PlayerInvencible(bool status)
    {
        playerInvencible_ = status;
    }
}
