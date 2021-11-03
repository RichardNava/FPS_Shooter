using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnBullet;
    public GameObject bullet;
    public ParticleSystem traceBullet;

    public float shotForce = 1500f;
    public float shotRace = 0.5f;
    public static float shotLifeTime = 4.5f; // Esta variable puede cambiar en función del arma que usemos

    private float shotRateTime = 0; //Cadencia
    public static bool weaponEquipped = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CameraController.CCenabled)
        {
            if (Time.time > shotRateTime && weaponEquipped)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnBullet.position, Quaternion.Euler(90,0,-90));
                newBullet.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * shotForce);
                traceBullet.Play();
                Destroy(newBullet, shotLifeTime);
            }
        }
    }
}
