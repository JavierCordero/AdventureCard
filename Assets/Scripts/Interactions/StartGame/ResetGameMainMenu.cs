using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameMainMenu : MonoBehaviour, InteractionInterface
{
    public Sprite IconSprite;

    public void ActionPerformed()
    {
        if (!PlayerManager.Instance.readyToPlay_)
        {
            FindObjectOfType<GeneralAnimationManager>().FadeIn();
            PlayerManager.Instance.readyToPlay_ = true;
            FindObjectOfType<PlayerMovement>().DisablePlayerMovement();
            Invoke("restartScene", 5);
        }
    }

    private void restartScene()
    {
        FindObjectOfType<MainMenuManager>().SetDay();
        FindObjectOfType<GeneralAnimationManager>().FadeOut();
        FindObjectOfType<PlayerMovement>().EnablePlayerMovement();
    }

    public Sprite getIcon()
    {
        return IconSprite;
    }
}
