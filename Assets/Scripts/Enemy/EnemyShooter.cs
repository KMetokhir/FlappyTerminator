using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [SerializeField] private uint _shootDelay;
    [SerializeField] private bool _isShotng;

    private Coroutine _coroutine; 
    
    private void Update()
    {
        _isShotng = _coroutine != null;
    }

    public void StartShooting()
    {
        if(_coroutine != null)
        {
            return;           
        }

        _coroutine = StartCoroutine(BurstFire(_shootDelay));

    }

    public void StopShooting()
    {

    }

    private IEnumerator BurstFire(uint delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Shoot();   
            yield return wait;
        }
    }
}
