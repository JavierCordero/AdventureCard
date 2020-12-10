using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName { UZI = 0 }
public enum ShootingMode { SINGLE = 0, BURST = 1, AUTO = 2 }

public class Weapon : MonoBehaviour
{

    public int _maxMagazineAmmu = 10;
    public int _reloadTime = 5;
    public int _bulletDamage = 10;
    public WeaponName _myWeaponName;
    public ShootingMode _myShootingMode;
    public float _cadency = 0.1f;
    public GameObject _weaponObject;
    public float _bulletDistance = 100;

    private float _currentShootTime = 0;
    private int _currentMagazineAmmu = 0;
    private bool _canShoot = true;
    private bool _reloading = false;

    private void Start()
    {
        _currentMagazineAmmu = _maxMagazineAmmu;
    }

    public void EnableWeapon()
    {
        if (_weaponObject)
            _weaponObject.SetActive(true);
    }

    public void DisableWeapon()
    {
        if (_weaponObject)
            _weaponObject.SetActive(false);
    }

    public void Shoot(Transform shootingPoint)
    {
        _currentShootTime += Time.deltaTime;

        Debug.DrawRay(shootingPoint.position, shootingPoint.forward * 100, Color.green);

        if (_canShoot)
        {
            if (_currentShootTime >= _cadency)
            {
                _currentShootTime = 0;

                if (_currentMagazineAmmu > 0)
                {

                    _currentMagazineAmmu--;

                    RaycastHit hit;
                    Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider != null && hit.distance < _bulletDistance && hit.collider.GetComponent<DamageObjectInterface>() != null)
                        {
                            Debug.Log("Enemy hit");
                            hit.collider.GetComponent<DamageObjectInterface>().Damage(_bulletDamage);
                        }
                    }
                }

                else if (!_reloading)
                {
                    _reloading = true;
                    _canShoot = false;
                    Invoke("reload", _reloadTime);
                }
            }
        }
    }

    private void reload()
    {
        Debug.Log("Reloading");
        _reloading = false;
        _currentMagazineAmmu = _maxMagazineAmmu;
        _canShoot = true;
    }
}
