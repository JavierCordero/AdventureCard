using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameInteraction : MonoBehaviour, InteractionInterface
{
    private bool interacted = false;
    public GameObject Animation;
    public GameObject Player;
    public GameObject VRHeadset;

    public void ActionPerformed()
    {
        if (!interacted && PlayerManager.Instance.readyToPlay_)
        {
            interacted = true;
            //FindObjectOfType<PlayerAnimationController>().StartGameAnimation();
            //FindObjectOfType<PlayerMovement>().DisablePlayerMovement();
            Animation.SetActive(true);
            Player.SetActive(false);
            VRHeadset.GetComponent<Renderer>().enabled = false;
        }
    }

    public void FinalStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
