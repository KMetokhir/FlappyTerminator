using UnityEngine;

public abstract class BulletRemover<T> : MonoBehaviour
    where T : Bullet
{
    [SerializeField] private ObjectPool<T> _pool;

    private void OnEnable()
    {
        _pool.ObjectGeted += OnObjectGetted;
    }

    private void OnDisable()
    {
        _pool.ObjectGeted -= OnObjectGetted;
    }

    private void OnObjectGetted(Bullet bullet)
    {
        bullet.BecameInvisible += OnBulletBecameInvisible;
    }

    private void OnBulletBecameInvisible(Bullet bullet)
    {
        bullet.BecameInvisible -= OnBulletBecameInvisible;
        _pool.PutObject(bullet as T);
    }
}