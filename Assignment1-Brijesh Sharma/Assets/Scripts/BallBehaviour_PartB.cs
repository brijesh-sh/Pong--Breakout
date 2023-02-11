using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour_PartB : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _force = 40;
    private Vector2 _contactPos;
    private Vector2 _paddlePos;
    private GameObject _player;
    [SerializeField] private AudioSource _wallCollision;
    [SerializeField] private AudioSource _paddleCollision;
    [SerializeField] private AudioSource _brickCollision;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBall()
    {
        float randAngle = Random.Range(30, 150);    // random angle from range 
        //Debug.Log(randAngle);
        float xcomponent = Mathf.Cos(randAngle * Mathf.PI / 180) * _force;
        float ycomponent = Mathf.Sin(randAngle * Mathf.PI / 180) * _force;
        _rb2d.AddForce(new Vector2(xcomponent, ycomponent));
        _player.GetComponent<PlayerControl_PartB>().enabled = true;
    }

    public void ResetBall()
    {
        transform.position = _player.transform.position;
        _player.GetComponent<PlayerControl_PartB>().enabled = false; // stopping the paddle
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        _rb2d.velocity = Vector2.zero;
    }
    public void Restart()
    {
        ResetBall();   // restrict paddle movement until ball starts moving
        Invoke("StartBall", 1);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            _paddleCollision.Play();               // paddle collision AudioSource
            _contactPos = collisionInfo.GetContact(0).point;   // contact point of the ball
            _paddlePos = collisionInfo.transform.position;

            // Changing the x component of velocity depending on where the ball hits the paddle

            _rb2d.velocity = new Vector2((6) * (_contactPos.x - _paddlePos.x), _rb2d.velocity.y);

            // Paddle collision edge radius set to 0.05 to minimize weird edge collisions

        }
        else if (collisionInfo.gameObject.tag == "Wall")
        {
            _wallCollision.Play();
        }

        else
        {
            _brickCollision.Play();
        }
    }
}

