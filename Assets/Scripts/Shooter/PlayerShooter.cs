using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {           
            Shoot();
        }      
    }    
}
