using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    public PlayerMovement player;
    public string lastMove = "";

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
        anim.SetBool("Jump", false);
        anim.SetBool("Block", false);

    }

    public void StartGameAnimation()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("StartGame", true);
        anim.SetBool("Jump", false);

    }

    public void Roll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", true);
        anim.SetBool("Jump", false);

    }

    public void EnableWalk()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Block", false);

    }

    public void EnableIdle()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Run", false);
        anim.SetBool("Block", false);

    }

    public void DisableAll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", false);
        anim.SetBool("AttackTrigger", false);
        anim.SetBool("Block", false);


    }

    public void EnableJump()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", true);

    }
    public void EnableBlock()
    {
        
        anim.SetBool("Block", true);

    }

    public void EnableAtack(int index)
    {
        anim.SetInteger("Atack", index);
        anim.SetBool("AttackTrigger", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AtackFinished()
    {
        anim.SetBool("AttackTrigger", false);
        
        
    }
    public void BlockFinished()
    {
        anim.SetBool("Block", false);
        player.playerInput.block = false;
        if (lastMove == "Walk")
            EnableWalk();
        else if (lastMove == "Run")
            EnableRun();
    }

}
