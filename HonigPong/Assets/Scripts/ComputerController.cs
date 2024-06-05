using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    private readonly float _speed = 7f;
    private readonly float _bounds = 3.75f;
    private GameObject _ball;
    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(_ball.transform.position);
    }

    private void Move(Vector2 target)
    {
        target = new Vector2(transform.position.x, target.y);
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if (transform.position.y > _bounds)
            transform.position = new Vector2(transform.position.x, _bounds);
        else if (transform.position.y < -_bounds)
            transform.position = new Vector2(transform.position.x, -_bounds);
    }
}
