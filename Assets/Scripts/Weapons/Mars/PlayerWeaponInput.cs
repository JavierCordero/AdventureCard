using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInput : MonoBehaviour
{
    public Transform _shootingPoint;

    private PlayerInputHandler _inputHandler;

    //TEST
    public Weapon _currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        _inputHandler = FindObjectOfType<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputHandler._shooting)
        {
            if(_currentWeapon)
                _currentWeapon.Shoot(_shootingPoint);
        }
    }
}
