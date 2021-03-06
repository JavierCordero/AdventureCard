﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FenceBehaviour : MonoBehaviour, InteractionInterface, DamageObjectInterface
{
    [SerializeField] private int fenceHP = 10;
    private int currentFenceHP;

    private GameObject brokenFence, normalFence;

    public Sprite repairIconSprite;

    private NavMeshObstacle myNavMesh;
    private Collider myCollider;

    private GameManager gm;

    private void Start()
    {
        currentFenceHP = fenceHP;
        normalFence = transform.GetChild(0).gameObject;
        brokenFence = transform.GetChild(1).gameObject;
        myNavMesh = GetComponent<NavMeshObstacle>();
        myCollider = GetComponent<Collider>();
        gm = FindObjectOfType<GameManager>();
    }

    public void FenceDamage(int dmg, DamagerInterface Damager)
    {
        currentFenceHP -= dmg;

        if(currentFenceHP <= 0)
        {
            normalFence.SetActive(false);
            brokenFence.SetActive(true);
            myNavMesh.enabled = false;
            myCollider.isTrigger = true;
            myCollider.enabled = false;
            if(Damager != null)
                Damager.StopAttacking();
            Invoke("restoreCollider", 10);
        }
    }

    private void restoreCollider()
    {
        myCollider.enabled = true;
    }

    public void RestoreFence()
    {
        if (currentFenceHP <= 0)
        {
            currentFenceHP = fenceHP;
            normalFence.SetActive(true);
            brokenFence.SetActive(false);
            myNavMesh.enabled = true;
            myCollider.isTrigger = false;
            gm.AddFence(gameObject);
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
        if (gm.numberOfWood > 0)
        {
            RestoreFence();
            gm.destroyWood();
        }
    }

    public void Damage(int dmg, DamagerInterface damager)
    {
        FenceDamage(dmg, damager);
    }
}
