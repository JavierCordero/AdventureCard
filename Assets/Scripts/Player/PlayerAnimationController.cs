using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        anim.SetBool("Jump", false);

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

    }

    public void EnableIdle()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Run", false);

    }

    public void DisableAll()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", false);

    }

    public void EnableJump()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Roll", false);
        anim.SetBool("Jump", true);

    }

    public void EnableAtack(int index)
    {
        anim.SetInteger("Atack", index);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
