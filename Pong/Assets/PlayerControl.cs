using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private KeyCode _moveUp = KeyCode.W;
    [SerializeField]
    private KeyCode _moveDown = KeyCode.S;
    private float _speed = 10f;
    private float _boundary = 2.25f;
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
        if (Input.GetKey(_moveUp))
        {
            vel.y = _speed;
        }
        else if (Input.GetKey(_moveDown))
        {
            vel.y = -_speed;
        }
        else
        {
            vel.y = 0;
        }
        _rb2d.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.y > _boundary)
        {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary)
        {
            pos.y = -_boundary;
        }
        transform.position = pos;

    }
}
