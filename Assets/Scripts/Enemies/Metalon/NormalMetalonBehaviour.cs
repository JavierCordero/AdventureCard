using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMetalonBehaviour : MonoBehaviour, DamageObjectInterface
{
    private GameManager gm;
    private UnityEngine.AI.NavMeshAgent myAgent;
    [HideInInspector]
    public GameObject target;
    public int Health = 20;

    private bool followingPlayer = false;

    private bool death = false; //Tecnicamente un zombie ya está muerto de base pero bueno, ya me entendéis

    public void Damage(int dmg, DamagerInterface Damager = null)
    {
        if (!death)
        {
            Health -= dmg;

            if (!followingPlayer)
                followingPlayer = true;

            if (Health <= 0)
            {
                death = true;
                //gm.KillEnemy();
                //zombieAnimator.SetFloat("Death", Random.Range(0, 2));
                //zombieAnimator.SetTrigger("Kill");
                Destroy(this.gameObject);
                Destroy(myAgent);
            }
        }
    }
}
