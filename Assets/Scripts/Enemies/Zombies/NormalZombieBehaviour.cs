using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalZombieBehaviour : MonoBehaviour, DamagerInterface, DamageObjectInterface
{
    private GameManager gm;
    private NavMeshAgent myAgent;
    [HideInInspector]
    public GameObject target;
    public int Health = 20;

    public NormalZombieAttack zombieAttackBehaviour;

    [SerializeField]
    private Animator zombieAnimator;

    private bool followingPlayer = false;

    private GameObject player;

    private bool interacted = false;

    private bool death = false; //Tecnicamente un zombie ya está muerto de base pero bueno, ya me entendéis

    private bool stunt = false, canMove = true;
    private void Start()
    {
        if (!gm)
            gm = FindObjectOfType<GameManager>();

        zombieAnimator.SetFloat("Walk", 0.2f);

        player = GameObject.FindGameObjectWithTag("Player");

        target = gm.GetClosestFence(transform.position);
        myAgent = GetComponent<NavMeshAgent>();

        if (target)
        {
            myAgent.SetDestination(target.transform.GetChild(2).position);
        }

        else followingPlayer = true;
    }

    private void Update()
    {
        if (canMove && myAgent)
        {
            if (followingPlayer)
            {
                myAgent.SetDestination(player.transform.position);
            }

            else myAgent.SetDestination(target.transform.GetChild(2).position);
        }

    }

    private void Attack()
    {
        if (!death && zombieAttackBehaviour && target)
        {
            zombieAnimator.SetFloat("Walk", 0f);
            zombieAttackBehaviour.ZombieAttackAnimation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!death && !interacted && other.gameObject.GetComponent<DamageObjectInterface>() != null)
        {
            target = other.gameObject;
            interacted = true;
            Attack();
            Invoke("StopInteraction", 2.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (target == other)
            target = null;
    }

    private void StopInteraction()
    {
        interacted = false;
    }

    void DamagerInterface.StopAttacking()
    {
        target = null;
        StopInteraction();
        followingPlayer = true;
        myAgent.isStopped = false;
        SetZombieMovement(true);
        zombieAnimator.SetFloat("Walk", 0.2f);
    }

    public void Damage(int dmg, DamagerInterface Damager = null)
    {
        Health -= dmg;

        if (!followingPlayer)
            followingPlayer = true;

        if (Health <= 0)
        {
            death = true;
            gm.KillEnemy();
            zombieAnimator.SetFloat("Death", Random.Range(0, 2));
            zombieAnimator.SetTrigger("Kill");
            Destroy(myAgent);
        }
        else if(!stunt)
        {
            SetZombieMovement(false);
            stunt = true;
            zombieAnimator.SetTrigger("Stunt");
        }
    }

    public void stopZombieStunt()
    {
        SetZombieMovement(true);
        stunt = false;
    }

    public void SetZombieMovement(bool m)
    {
        if (!m)
            myAgent.isStopped = true;
        else myAgent.isStopped = false;

        canMove = m;
    }

}
