using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameInteraction : MonoBehaviour, InteractionInterface
{
    private bool interacted = false;

    public void ActionPerformed()
    {
        if (!interacted && PlayerManager.Instance.readyToPlay_)
        {
            interacted = true;
            //FindObjectOfType<PlayerAnimationController>().StartGameAnimation();
            //FindObjectOfType<PlayerMovement>().DisablePlayerMovement();
            SceneManager.LoadScene("GameScene");
        }
    }
}
