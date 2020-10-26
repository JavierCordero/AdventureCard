using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FenceBehaviour : MonoBehaviour, InteractionInterface, DamageObjectInterface
{
    [SerializeField] private int fenceHP = 10;
    public int currentFenceHP;

    private GameObject brokenFence, normalFence;

    public Sprite repairIconSprite;

    private NavMeshObstacle myNavMesh;
    private Collider myCollider;

    private void Start()
    {
        currentFenceHP = fenceHP;
        normalFence = transform.GetChild(0).gameObject;
        brokenFence = transform.GetChild(1).gameObject;
        myNavMesh = GetComponent<NavMeshObstacle>();
        myCollider = GetComponent<Collider>();
    }

    public void FenceDamage(int dmg)
    {
        currentFenceHP -= dmg;

        if(currentFenceHP <= 0)
        {
            normalFence.SetActive(false);
            brokenFence.SetActive(true);
            myNavMesh.enabled = false;
            myCollider.isTrigger = true;
        }
    }

    public void RestoreFence()
    {
        if (currentFenceHP <= 0)
        {
            normalFence.SetActive(true);
            brokenFence.SetActive(false);
            myNavMesh.enabled = true;
            myCollider.isTrigger = false;
        }
    }

    public Sprite getIcon()
    {
        if (currentFenceHP <= 0)
            return repairIconSprite;
        else return null;
    }

    public void ActionPerformed()
    {
        Debug.Log("Repairing");
    }

    public void Damage(int dmg)
    {
        FenceDamage(dmg);
    }
}
