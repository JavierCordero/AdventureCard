using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerInputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = FindObjectOfType<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHandler._shooting)
        {
            Debug.Log("pium");
        }
    }
}
