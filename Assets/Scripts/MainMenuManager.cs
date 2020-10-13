using UnityEngine;
using UnityEngine.Rendering;

public enum CurrentPlayerFloor { UpperFloor, LowerFloor };

public class MainMenuManager : MonoBehaviour
{
    public GameObject UpperFloor, LowerFloor, DayLights, NightLights, Player;
    public VolumeProfile DayProfile, NightProfile;
    public Volume PostProcessVolume;
    public Material DaySkybox, NightSkybox;
    public Transform NightPlayerStandpoint, DayPlayerStandpoint;

    public GameObject[] OpenDayDoors, OpenNightDoors;

    CurrentPlayerFloor myFloor = CurrentPlayerFloor.UpperFloor;

    private void Start()
    {
        changePlayerCurrentFloor(CurrentPlayerFloor.UpperFloor);
        if (PlayerManager.Instance.readyToPlay_)
            SetDay();
        else SetNight();
    }

    public void SetNight()
    {
        RenderSettings.skybox = NightSkybox;
        PostProcessVolume.profile = NightProfile;
        DayLights.SetActive(false);
        NightLights.SetActive(true);
        Player.transform.position = NightPlayerStandpoint.position;
        UpperFloor.SetActive(false);

        foreach (GameObject g in OpenNightDoors)
            g.GetComponent<Animator>().SetBool("OpenDoor", true);
    }

    public void SetDay()
    {
        RenderSettings.skybox = DaySkybox;
        PostProcessVolume.profile = DayProfile;
        DayLights.SetActive(true);
        NightLights.SetActive(false);

        Player.transform.position = DayPlayerStandpoint.position;

        foreach (GameObject g in OpenDayDoors)
            g.GetComponent<Animator>().SetBool("OpenDoor", true);
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
