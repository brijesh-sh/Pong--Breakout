using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _force = 32;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            _rb2d.AddForce(new Vector2(_force, -10));
        }
        else
        {
            _rb2d.AddForce(new Vector2(-_force, -10));
        }
    }

    public void ResetBall()
    {
        _rb2d.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }
    public void Restart()
    {
        ResetBall();
        Invoke("StartBall", 1);
    }
}
