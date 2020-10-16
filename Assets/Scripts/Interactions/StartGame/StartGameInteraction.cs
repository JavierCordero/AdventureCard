using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameInteraction : MonoBehaviour, InteractionInterface
{
    private bool interacted = false;
    public GameObject Animation;
    public GameObject Player;
    public GameObject VRHeadset;
    public GameObject playerInteractionIcon;

    public void ActionPerformed()
    {
        if (!interacted && PlayerManager.Instance.readyToPlay_)
        {
            interacted = true;
            //FindObjectOfType<PlayerAnimationController>().StartGameAnimation();
            //FindObjectOfType<PlayerMovement>().DisablePlayerMovement();
            Animation.SetActive(true);
            Player.SetActive(false);
            playerInteractionIcon.SetActive(false);
            VRHeadset.GetComponent<Renderer>().enabled = false;
            
        }
    }

    public void FinalStartGame()
    {
        FindObjectOfType<GeneralAnimationManager>().FadeIn();
        //SceneManager.LoadScene("GameScene");
    }
}
