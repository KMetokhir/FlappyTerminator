using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool <T>: MonoBehaviour
    where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    public event Action<T> ObjectGeted;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObject()
    {
        if(_pool.Count == 0)
        {
            T newObject = Instantiate(_prefab);//.GetComponent<T>();
            //pipe.transform.parent = _container;
            ObjectGeted?.Invoke(newObject);

            return newObject;
        }

        T objectFromPool = _pool.Dequeue();
        ObjectGeted?.Invoke(objectFromPool);

        return objectFromPool;
    }

    public void PutObject(T pipe)
    {
        _pool.Enqueue(pipe);
        pipe.gameObject.SetActive(false);
    }

    public void Restart()
    {
        _pool.Clear();
    }
}
