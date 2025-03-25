using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;

    public event Action EnemyRemoved;

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    private void OnEnable()
    {
        _pool.ObjectGeted += OnObjectGetted;
    }

    private void OnDisable()
    {
        _pool.ObjectGeted -= OnObjectGetted;
    }

    private void OnObjectGetted(Enemy enemy)
    {
        enemy.Destroyed += OnEnemyDestroyed;
    }
    private void OnEnemyDestroyed(Enemy enemy)
    {
        enemy.Destroyed -= OnEnemyDestroyed;
        EnemyRemoved?.Invoke();
        _pool.PutObject(enemy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }
    }
}