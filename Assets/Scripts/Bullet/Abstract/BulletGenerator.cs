using UnityEngine;

public abstract class BulletGenerator<T> : MonoBehaviour
    where T : Bullet
{
    [SerializeField] private ObjectPool<T> _pool;

    public Bullet Generate(Vector2 position, Quaternion rotation)
    {
        Bullet bullet = _pool.GetObject();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }
}