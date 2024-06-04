using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    private readonly float _speed = 10f;
    private readonly float _moveThreshhold = .2f;
    private Vector2 _ballPosition = Vector2.zero;
    private Rigidbody2D _rb;
    private GameObject _ball;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        _ballPosition = _ball.transform.position;
        Move(_ballPosition);
    }

    private void FixedUpdate()
    {
    }

    private void Move(Vector2 target)
    {
        var diff = target.y - transform.position.y;
        if (Mathf.Abs(diff) > _moveThreshhold)
        {
            diff /= Mathf.Abs(diff);
            _rb.velocity = new Vector2(0, diff * _speed);
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Solid"))
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
