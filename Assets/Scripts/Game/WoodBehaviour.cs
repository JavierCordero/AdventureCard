using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBehaviour : MonoBehaviour, InteractionInterface
{
    public Sprite icon;

    public int numberOfWoodPerRound = 5;
    public int currentWood = 0;

    private GameManager gm;

    private void Start()
    {
        restoreWood();
        gm = FindObjectOfType<GameManager>();
    }

    public void ActionPerformed()
    {
        if (gm.addWood() && currentWood > 0)
            currentWood--;
    }

    public void restoreWood()
    {
        currentWood = numberOfWoodPerRound;
    }

    public Sprite getIcon()
    {
        return icon;
    }
}
