using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnBullet;

    //public GameObject bullet;

    // Esta variable puede cambiar en función del arma que usemos

    private float shotRateTime = 0; //Cadencia
    public static bool weaponEquipped = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CameraController.CCenabled)
        {
            if (Time.time > shotRateTime && weaponEquipped)
            {
                //GameObject newBullet = Instantiate(bullet);
                //newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shotForce);             
                //Destroy(newBullet, shotLifeTime);
                Pool.instance.Get().transform.position = spawnBullet.position;

            }
        }
    }
}
