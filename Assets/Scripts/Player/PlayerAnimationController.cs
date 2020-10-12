using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    public PlayerMovement player; 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EnableRun()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
    }

    public void Roll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", true);
    }

    public void EnableWalk()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
    }

    public void EnableIdle()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Roll", false);
    }

    public void DisableAll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
    }

    public void EnableAtack(int index)
    {
        anim.SetInteger("Atack", index);
    }

}
