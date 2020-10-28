using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int Damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DamageObjectInterface>() != null && !other.CompareTag("Player"))
        {
            other.GetComponent<DamageObjectInterface>().Damage(Damage);
        }
    }
}
