using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<IInteracteble> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracteble interacteble))
        {
            CollisionDetected?.Invoke(interacteble);
        }
    }
}
