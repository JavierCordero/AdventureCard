using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private List<GameObject> Fences;

    // Start is called before the first frame update
    void Awake()
    {
        Fences = new List<GameObject>();

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Fence"))
            Fences.Add(g);
    }


    public GameObject GetClosestFence(Vector3 position)
    {
        float minDist = float.MaxValue;
        GameObject closest = null;


        foreach(GameObject g in Fences)
        {
            float dist = Vector3.Distance(position, g.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = g;
            }
        }

        if (closest)
            Fences.Remove(closest);

        return closest;
    }

}
