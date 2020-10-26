using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalZombieBehaviour : MonoBehaviour
{
    private GameManager gm;
    private NavMeshAgent myAgent;
    private GameObject targetFence;

    private bool stoppedInTargetDoor = false;

    public NormalZombieAttack zombieAttackBehaviour;

    [SerializeField]
    private Animator zombieAnimator;

    private bool followingPlayer = false;

    private GameObject player;

    private void Start()
    {
        if (!gm)
            gm = FindObjectOfType<GameManager>();

        zombieAnimator.SetFloat("Walk", 0.2f);

        player = GameObject.FindGameObjectWithTag("Player");

        targetFence = gm.GetClosestFence(transform.position);
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.SetDestination(targetFence.transform.GetChild(2).position);
    }

    private void Update()
    {
        if (!stoppedInTargetDoor && myAgent.remainingDistance <= 0)
        {
            stoppedInTargetDoor = true;
            myAgent.isStopped = true;

            Attack();
            //ZombieAttack();
        }

        if (followingPlayer)
        {
            myAgent.isStopped = false;
            myAgent.SetDestination(player.transform.position);
        }

    }

   private void Attack()
    {
        if (zombieAttackBehaviour)
        {
            zombieAnimator.SetFloat("Walk", 0f);
            zombieAttackBehaviour.target = targetFence;
            zombieAttackBehaviour.ZombieAttackAnimation();
        }

        if (targetFence.GetComponent<FenceBehaviour>().currentFenceHP > 0)
            Invoke("Attack", 2.5f);
        else
        {
            followingPlayer = true;
            zombieAnimator.SetFloat("Walk", 0.2f);
        }

    }

}
