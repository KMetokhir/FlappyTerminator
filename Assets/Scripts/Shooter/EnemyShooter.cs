using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter<EnemyBullet>
{
    [SerializeField] private uint _shootDelay;

    private Coroutine _coroutine;

    private void OnDisable()
    {
        _coroutine = null;
    }

    public void SetBulletGenerator(BulletGenerator<EnemyBullet> bulletGenerator)
    {
        if (_bulletGenerator != null)
        {
            return;
        }

        _bulletGenerator = bulletGenerator;
    }

    public void StartShooting()
    {
        if (_coroutine != null)
        {
            return;
        }

        _coroutine = StartCoroutine(BurstFire(_shootDelay));
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