using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;
    private Vector3 _direction;
    private bool[] _collisionDetected;
    private void Start()
    {
        _collisionDetected = new bool[4];
        _direction = Vector3.zero;
    }

    private void Update()
    {
        SetDirection();
        Move(_direction);
    }

    private void SetDirection()
    {
        var dx = Input.GetAxisRaw("Horizontal");
        var dy = Input.GetAxisRaw("Vertical");
        dx = dx > 0 && _collisionDetected[1] ? 0 : dx;
        dx = dx < 0 && _collisionDetected[3] ? 0 : dx;

        dy = dy > 0 && _collisionDetected[0] ? 0 : dy;
        dy = dy < 0 && _collisionDetected[2] ? 0 : dy;
        
        _direction.x = dx;
        _direction.y = dy;
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir.normalized * (_moveSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Wall"))
            return;
        var tolerance = 0.1f;
        var contact = collision.GetContact(0);
        _collisionDetected[0] = contact.normal.y < -tolerance;
        _collisionDetected[1] = contact.normal.x < -tolerance;
        _collisionDetected[2] = contact.normal.y > tolerance;
        _collisionDetected[3] = contact.normal.x > tolerance;
        
        Debug.Log(contact.normal);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        for (int i = 0; i < _collisionDetected.Length; i++)
            _collisionDetected[i] = false;
    }
}