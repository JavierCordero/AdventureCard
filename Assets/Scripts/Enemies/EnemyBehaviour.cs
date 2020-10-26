using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player_;
    private NavMeshAgent myAgent_;
    private bool rangeToAttack_ = false;
    private Animator myAnimator_;

    public void Init(GameObject player, Animator enemyAnimator)
    {
        player_ = player;
        myAgent_ = GetComponent<NavMeshAgent>() ?? gameObject.AddComponent<NavMeshAgent>();
        myAnimator_ = enemyAnimator;

        myAnimator_.SetBool("Walk", true);
        myAgent_.SetDestination(player_.transform.position);

    }

    private void Update()
    {
        if (!rangeToAttack_)
            myAgent_.SetDestination(player_.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rangeToAttack_ = true;
            Attack();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            rangeToAttack_ = false;
    }

    private void Attack()
    {
        Debug.Log("En tu face");

        if (rangeToAttack_)
            Invoke("Attack", Random.Range(0.5f, 3));

    }

}
