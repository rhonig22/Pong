using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private readonly float _startSpeed = 10f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartMoving();
    }

    public void StartMoving()
    {
        Vector2 startDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _rb.velocity = startDirection * _startSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Solid"))
        {
            // _rb.velocity = Vector2.Reflect(_rb.velocity, collision.contacts[0].normal);
        }
    }
}
