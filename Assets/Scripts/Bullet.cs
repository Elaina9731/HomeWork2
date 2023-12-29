using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    Rigidbody2D _rb;
    public float speed = 5f;
    public float bulletDuration = 3f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Shooting");
    }

    IEnumerator Shooting()
    {
        float timer = 0f;
        while (true)
        {
            _rb.AddForce(Vector2.right * speed);
            timer += Time.deltaTime;
            if (timer > bulletDuration)
                break;
            yield return null;
        }

        ObjectPool.ReturnObj(this);
    }
}
