using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AimRotation : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private SpriteRenderer _rend;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    void OnAim(Vector2 dir)
    {
        Rotate(dir);
    }

    void Rotate(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _rend.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
