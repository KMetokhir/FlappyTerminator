using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyGenerator : MonoBehaviour
  
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<Enemy> _pool;

    private Coroutine _coroutine;

    /*private void Start()
    {
        
    }*/

    public void Generate()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(GeneratePipes());
    }

    public void Restart()
    {
        _pool.Restart();
        Generate();       
    }

    private IEnumerator GeneratePipes()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoimt = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy pipe = _pool.GetObject();
        pipe.transform.position = spawnPoimt;
    }
}
