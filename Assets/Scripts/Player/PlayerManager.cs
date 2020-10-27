using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Singleton<PlayerManager>
{

    public int playerHP_;
    private int currentPlayerHP_;
    private bool playerInvencible_ = false;
    public bool readyToPlay_ = true;

    void Start()
    {
        currentPlayerHP_ = playerHP_;
    }

    public void DamagePlayer(int dmg)
    {
        if (!playerInvencible_)
        {
            currentPlayerHP_ -= dmg;

            if (currentPlayerHP_ <= 0)
                KillPlayer();
        }
    }

    private void KillPlayer()
    {
        readyToPlay_ = false;
        SceneManager.LoadScene("MainMenuScene");
        currentPlayerHP_ = playerHP_;
    }

    public void PlayerInvencible(bool status)
    {
        playerInvencible_ = status;
    }
}
