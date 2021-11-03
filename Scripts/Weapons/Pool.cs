using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pool : MonoBehaviour
{
    public static Pool instance { get; private set; }
    public GameObject prefab;
    public int initalAmount = 100;

    List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < initalAmount; i++)
        {
            GameObject go = Instantiate(prefab);
            go.SetActive(false);

            pool.Add(go);
        }
    }

    public GameObject Get()
    {
        GameObject ret;

        if (pool.Count > 0)
        {
            ret = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);
        }
        else
        {
            ret = Instantiate(prefab);
        }

        ret.SetActive(true);
        return ret;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        pool.Add(go);
    }
}
