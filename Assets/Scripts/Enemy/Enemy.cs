using System;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(EnemyShooter), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, IDestroyable, IInteracteble
{
    [SerializeField] private EnemyShooter _shooter;

    private bool _isActivated = false;

    public event Action<Enemy> Destroyed;

    private void OnBecameVisible()
    {
        if (_isActivated)
        {
            _shooter.StartShooting();
        }
        else
        {
            throw new Exception("Enemy " + ToString() + " doesn't activated with shooter");
        }
    }

    public void ActivateShooter(EnemyBulletGenerator bulletGenerator)
    {
        if (_isActivated)
        {
            return;
        }

        _isActivated = true;
        _shooter.SetBulletGenerator(bulletGenerator);
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
    }
}