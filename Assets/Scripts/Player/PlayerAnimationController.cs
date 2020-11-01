using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    public PlayerMovement player;
    public string lastMove = "";
    public GameObject sword;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EnableRun()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        //anim.SetBool("Roll", false);
        //anim.SetBool("Jump", false);
        //anim.SetBool("Block", false);

    }

    public void StartGameAnimation()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        //anim.SetBool("Roll", false);
        anim.SetBool("StartGame", true);
        //anim.SetBool("Jump", false);

    }

    public void Roll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
       //anim.SetBool("Roll", true);
       //anim.SetBool("Jump", false);

    }

    public void EnableWalk()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        //anim.SetBool("Roll", false);
        //anim.SetBool("Jump", false);
        //anim.SetBool("Block", false);

    }

    public void EnableIdle()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        //anim.SetBool("Roll", false);
        //anim.SetBool("Jump", false);
        anim.SetBool("Run", false);
        //anim.SetBool("Block", false);

    }

    public void DisableAll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        //anim.SetBool("Roll", false);
        //anim.SetBool("Jump", false);
        //anim.SetBool("AttackTrigger", false);
        //anim.SetBool("Block", false);


    }

    //public void EnableJump()
    //{
    //    anim.SetBool("Run", false);
    //    anim.SetBool("Walk", false);
    //    anim.SetBool("Idle", false);
    //    anim.SetBool("Roll", false);
    //    anim.SetBool("Jump", true);

    //}
    public void EnableBlock()
    {   
        anim.SetTrigger("Block");
        player.playerCanMove = false;
    }

    public void EnableAtack(float index)
    {
        if (!sword.activeSelf)
        {
            player.playerCanMove = false;
            anim.SetFloat("Atack", index);
            anim.SetTrigger("AttackTrigger");
            sword.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AtackFinished()
    {
        player.playerCanMove = true;
        sword.SetActive(false);
    }
    public void BlockFinished()
    {
        player.playerCanMove = true;
        //anim.SetBool("Block", false);
        player.playerInput.block = false;
        //if (lastMove == "Walk")
        //    EnableWalk();
        //else if (lastMove == "Run")
        //    EnableRun();
    }

}
