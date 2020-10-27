using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombieAttack : MonoBehaviour
{
    private Animator zombieAnimator;

    [HideInInspector] public GameObject target;
    public void ZombieAttackAnimation()
    {

        if (!zombieAnimator)
            zombieAnimator = GetComponent<Animator>();

        zombieAnimator.SetTrigger("Attack");

        //Invoke("ZombieAttackAnimation", 2);
    }

    public void ZombieAttackDamage()
    {
        target.GetComponent<DamageObjectInterface>().Damage(5, transform.parent.GetComponent<DamagerInterface>());
    }

}
