using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float shotForce = 500f;
    public static float shotLifeTime = 4.5f;

    public Rigidbody rb;

    private void OnEnable()
    {
        StartCoroutine(ReturnToPoolCoroutine());
    }

    IEnumerator ReturnToPoolCoroutine()
    {
        yield return new WaitForSeconds(shotLifeTime);
        Pool.instance.Return(gameObject);
    }

    void Update()
    {
        rb.AddForce(transform.forward * shotForce, ForceMode.Impulse);
    }
}
