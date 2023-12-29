using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rb;

    [SerializeField] private float playerSpeed = 5f;
    private Vector2 _moveDir = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 dir)
    {
        _moveDir = dir;
    }

    private void FixedUpdate()
    {
        ApplyMoveMent(_moveDir);
    }

    void ApplyMoveMent(Vector2 dir)
    {
        _rb.velocity = dir * playerSpeed;
    }
}
