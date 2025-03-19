using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour, IDestroyable, IInteracteble 
{
    [SerializeField] private EnemyShooter _shooter;
    private bool _isActivated = false;    

    public event Action<Enemy> Destroyed;   

    public void ActivateShooter(EnemyBulletGenerator bulletGenerator)
    {
        if (_isActivated)
        {
            return;
        }        
        _isActivated = true;
        _shooter.SetBulletGenerator(bulletGenerator);
    }
    private void OnBecameVisible()
    {
        Debug.Log("Visible");

        if (_isActivated)
        {
            _shooter.StartShooting();
        }
        else
        {
            throw new Exception("Enemy "+ToString() +" doesn't activated with shooter");
        }
    }

    public void Destroy()
    {        
        Destroyed?.Invoke(this);
    }    
}
