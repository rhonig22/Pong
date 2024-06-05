using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] AudioClip _bounceSound;
    private readonly float _startSpeed = 10f;
    private readonly float _xBounds = 8f;
    private readonly float _speedIncrement = .2f;
    private float _currentSpeed = 10f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForPoint();
    }

    public void StartMoving()
    {
        Vector2 startDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _currentSpeed = _startSpeed;
        _rb.velocity = startDirection * _startSpeed;
    }

    private void CheckForPoint()
    {
        if (transform.position.x > _xBounds)
        {
            GameManager.Instance.PlayerPoint();
            _rb.velocity = Vector2.zero;
        }
        else if (transform.position.x < -_xBounds)
        {
            GameManager.Instance.ComputerPoint();
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.Instance.PlaySound(_bounceSound, transform.position);
        _currentSpeed += _speedIncrement;
        var currentDirection = _rb.velocity.normalized;
        _rb.velocity = currentDirection * _currentSpeed;
    }
}
