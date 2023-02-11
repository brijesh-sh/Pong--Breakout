using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_PartB : MonoBehaviour
{
    [SerializeField]
    private KeyCode _moveRight = KeyCode.D;
    [SerializeField]
    private KeyCode _moveLeft = KeyCode.A;
    private float _speed = 10f;
    private float _boundary = 4.3f;
    private Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = _rb2d.velocity;
        if (Input.GetKey(_moveRight))
        {
            vel.x = _speed;
        }
        else if (Input.GetKey(_moveLeft))
        {
            vel.x = -_speed;
        }
        else
        {
            vel.x = 0;
        }
        _rb2d.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.x > _boundary)
        {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary)
        {
            pos.x = -_boundary;
        }
        transform.position = pos;

    }

    
}
