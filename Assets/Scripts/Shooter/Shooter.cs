using System;
using UnityEngine;

public abstract class Shooter<T> : MonoBehaviour
    where T : Bullet
{
    [SerializeField] protected BulletGenerator<T> _bulletGenerator;
    
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce;

    private void OnValidate()
    {
        _shootForce = Mathf.Abs(_shootForce);
    }    
    protected void Shoot()
    {
        if (_bulletGenerator == null)
        {
            throw new Exception("BulletGenerator in shooter = null");
        }
        
        Bullet bullet = _bulletGenerator.Generate(_shootPoint.position, _shootPoint.rotation);
        bullet.AddForce(_shootForce);
    }
}