using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentControl : MonoBehaviour
{
    private Vector2 _ballPosY = new Vector2(4, 0);
    private float _speed = 1.72f;
    private float _boundary = 2.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _ballPosY.y = GameObject.Find("Ball").transform.position.y;
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

        
        transform.position = Vector2.MoveTowards(transform.position, _ballPosY, _speed*Time.deltaTime);


    }
}
