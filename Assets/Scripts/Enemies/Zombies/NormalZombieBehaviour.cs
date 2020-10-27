using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalZombieBehaviour : MonoBehaviour, DamagerInterface
{
    private GameManager gm;
    private NavMeshAgent myAgent;
    private GameObject target;


    public NormalZombieAttack zombieAttackBehaviour;

    [SerializeField]
    private Animator zombieAnimator;

    private bool followingPlayer = false;

    private GameObject player;

    private bool interacted = false;

    private void Start()
    {
        if (!gm)
            gm = FindObjectOfType<GameManager>();

        zombieAnimator.SetFloat("Walk", 0.2f);

        player = GameObject.FindGameObjectWithTag("Player");

        target = gm.GetClosestFence(transform.position);
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.SetDestination(target.transform.GetChild(2).position);
    }

    private void Update()
    {
        if (followingPlayer)
        {
            myAgent.SetDestination(player.transform.position);
        }

    }

    private void Attack()
    {
        if (zombieAttackBehaviour && target)
        {
            zombieAnimator.SetFloat("Walk", 0f);
            zombieAttackBehaviour.target = target;
            zombieAttackBehaviour.ZombieAttackAnimation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!interacted && other.gameObject.GetComponent<DamageObjectInterface>() != null)
        {
            target = other.gameObject;
            interacted = true;
            Attack();
            Invoke("StopInteraction", 2.5f);
        }
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
        zombieAnimator.SetFloat("Walk", 0.2f);
    }
}
