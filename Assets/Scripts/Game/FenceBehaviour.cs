using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBehaviour : MonoBehaviour, InteractionInterface
{
    [SerializeField] private int fenceHP = 10;
    public int currentFenceHP;

    private GameObject brokenFence, normalFence;

    public Sprite repairIconSprite;

    private void Start()
    {
        currentFenceHP = fenceHP;
        normalFence = transform.GetChild(0).gameObject;
        brokenFence = transform.GetChild(1).gameObject;
    }

    public void FenceDamage(int dmg)
    {
        currentFenceHP -= dmg;

        if(currentFenceHP <= 0)
        {
            normalFence.SetActive(false);
            brokenFence.SetActive(true);
        }
    }

    public void RestoreFence()
    {
        if (currentFenceHP <= 0)
        {
            normalFence.SetActive(true);
            brokenFence.SetActive(false);
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
}
