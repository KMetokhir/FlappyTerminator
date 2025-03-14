using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        /* var rigi = GetComponent<Rigidbody2D>();
         rigi.useFullKinematicContacts = true;*/
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        _pool.ObjectGeted += OnObjectGetted;
    }

    private void OnObjectGetted(Enemy enemy)
    {
        enemy.Destroyed += OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        enemy.Destroyed -= OnEnemyDestroyed;
        _pool.PutObject(enemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Enemy Removed in trigger");

            _pool.PutObject(enemy);
        }
    }
}
