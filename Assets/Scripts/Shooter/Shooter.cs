using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private BulletGenerator _bulletGenerator;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce;

    private void OnValidate()
    {
        _shootForce = Mathf.Abs(_shootForce);
        
    }

    private void Awake()
    {
        _bulletGenerator = FindObjectOfType<BulletGenerator>();
    }

    protected  void Shoot()
    {
        Bullet bullet = _bulletGenerator.Generate(_shootPoint.position, _shootPoint.rotation);
        bullet.AddForce(_shootForce);
    }
}
