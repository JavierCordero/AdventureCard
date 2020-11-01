using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalZombieAttack : MonoBehaviour
{
    private Animator zombieAnimator;

    [HideInInspector] public GameObject target;

    private NormalZombieBehaviour zombie;

    private void Start()
    {
        zombie = GetComponent<NormalZombieBehaviour>();
    }

    public void ZombieAttackAnimation()
    {

        if (!zombieAnimator)
            zombieAnimator = GetComponent<Animator>();

        zombieAnimator.SetTrigger("Attack");

        zombie.SetZombieMovement(false);


        //Invoke("ZombieAttackAnimation", 2);
    }

    public void ZombieAttackDamage()
    {
        target = zombie.target;

        if (target && target.GetComponent<DamageObjectInterface>() != null)
            target.GetComponent<DamageObjectInterface>().Damage(5, GetComponent<DamagerInterface>());
    }

    public void StopAttack()
    {
        zombie.SetZombieMovement(true);
    }

}
