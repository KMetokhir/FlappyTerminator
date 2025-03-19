using UnityEngine;

public abstract class  BulletGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bullet> _pool;

    public Bullet Generate(Vector2 position, Quaternion rotation)
    {
        Bullet pipe = _pool.GetObject();
        pipe.transform.position = position;
        pipe.transform.rotation = rotation;

        return pipe;
    }    
}
