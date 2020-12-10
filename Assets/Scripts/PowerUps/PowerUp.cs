using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    GameManager gm;

    public GameManager.PowerUps myPowerUp = GameManager.PowerUps.BACKPACK;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.setPowerUp(myPowerUp);
            Destroy(gameObject);
        }
    }
}
