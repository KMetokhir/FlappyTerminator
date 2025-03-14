using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour, IDestroyable, IInteracteble 
{
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private bool _isVisible=false;

    public event Action<Enemy> Destroyed;

    private void Start()
    {
        //_shooter = FindAnyObjectByType<EnemyShooter>();
        _isVisible = false;

        //_shooter.StartShooting();
    }

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
        _isVisible = true;
        _shooter.StartShooting();
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
    }    
}
