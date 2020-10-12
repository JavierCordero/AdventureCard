using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentPlayerFloor { UpperFloor, LowerFloor };

public class MainMenuManager : MonoBehaviour
{
    public GameObject UpperFloor, LowerFloor;

    CurrentPlayerFloor myFloor = CurrentPlayerFloor.UpperFloor;

    private void Start()
    {
        changePlayerCurrentFloor(CurrentPlayerFloor.UpperFloor);
    }

    public CurrentPlayerFloor getCurrentPlayerFloor()
    {
        return myFloor;
    }

    public void changePlayerCurrentFloor(CurrentPlayerFloor floor)
    {
        myFloor = floor;

        if (myFloor == CurrentPlayerFloor.UpperFloor)
        {
            UpperFloor.SetActive(true);
            LowerFloor.SetActive(true);
        }


        else if (myFloor == CurrentPlayerFloor.LowerFloor)
        {
            LowerFloor.SetActive(true);
            UpperFloor.SetActive(false);
        }

    }


}
