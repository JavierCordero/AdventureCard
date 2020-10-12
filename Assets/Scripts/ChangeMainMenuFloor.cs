using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMainMenuFloor : MonoBehaviour
{

    public CurrentPlayerFloor myFloor;
    private MainMenuManager menuManager_;
    private void Start()
    {
        menuManager_ = FindObjectOfType<MainMenuManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (myFloor != menuManager_.getCurrentPlayerFloor())
                menuManager_.changePlayerCurrentFloor(myFloor);
        }
    }
}
