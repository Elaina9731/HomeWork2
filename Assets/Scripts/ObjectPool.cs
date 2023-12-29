using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;

    Queue<Bullet> bulletQueue = new Queue<Bullet>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

        Init();
    }

    private void Init()
    {
        for (int i = 0; i < poolSize; i++)
        {
            bulletQueue.Enqueue(CreateObj());
        }
    }

    private Bullet CreateObj()
    {
        Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(transform);
        return bullet;
    }

    public static Bullet GetObj()
    {
        if (instance.bulletQueue.Count > 0)
        {
            Bullet bullet = instance.bulletQueue.Dequeue();
            bullet.transform.SetParent(null);
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            Bullet bullet = instance.CreateObj();
            bullet.gameObject.SetActive(true);
            bullet.transform.SetParent(null);
            return bullet;
        }
    }

    public static void ReturnObj(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(instance.transform);
        instance.bulletQueue.Enqueue(bullet);
    }
}
