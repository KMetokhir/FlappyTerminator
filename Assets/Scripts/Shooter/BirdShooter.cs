using UnityEngine;

public class BirdShooter : Shooter<BirdBullet>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Shoot();
        }
    }
}