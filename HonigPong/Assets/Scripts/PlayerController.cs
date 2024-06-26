using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private readonly float _bounds = 3.75f;
    private Vector2 _mousePosition = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Move(_mousePosition);
    }

    private void Move(Vector2 mouse)
    {
        transform.position = new Vector2(transform.position.x, mouse.y);

        if (transform.position.y > _bounds)
            transform.position = new Vector2(transform.position.x, _bounds);
        else if (transform.position.y < -_bounds)
            transform.position = new Vector2(transform.position.x, -_bounds);
    }
}
