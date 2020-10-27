using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, DamageObjectInterface
{
    public void Damage(int dmg, DamagerInterface Damager)
    {
        PlayerManager.Instance.DamagePlayer(dmg);
    }
}
