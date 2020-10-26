using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    public Animator myAnimator_;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.AddComponent<EnemyBehaviour>();
            EnemyBehaviour e = gameObject.GetComponent<EnemyBehaviour>();
            e.Init(other.gameObject, myAnimator_);
            GetComponent<SphereCollider>().radius = 2;
            Destroy(this);
        }
    }
}
