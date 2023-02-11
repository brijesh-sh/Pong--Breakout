using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour_PartA : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _force = 32;
    private float _paddleForceY = 10;
    private float _paddleForceX = 6;
    private Vector2 _contactPos;
    private Vector2 _paddlePos;
    [SerializeField] private AudioSource _wallCollision;
    [SerializeField] private AudioSource _hitCollision;


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
        float randAngle = Random.Range(120, 210 );    // random angle from range 
        //Debug.Log(randAngle);
        float xcomponent = Mathf.Cos(randAngle * Mathf.PI / 180) * _force;
        float ycomponent = Mathf.Sin(randAngle * Mathf.PI / 180) * _force;
        
        float rand = Random.Range(0, 2);        // force direction
        //Debug.Log(rand);
        if (rand < 1)
        {
            _rb2d.AddForce(new Vector2(xcomponent, ycomponent));
        }
        else
        {
            _rb2d.AddForce(new Vector2(-xcomponent, ycomponent));
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

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            _hitCollision.Play();    // hit collision audio
            _contactPos = collisionInfo.GetContact(0).point;   // contact point of the ball
            _paddlePos = collisionInfo.transform.position;

            // Changing the y component of velocity depending on where the ball hits the paddle
             
            _rb2d.velocity = new Vector2(_rb2d.velocity.x , (6) * (_contactPos.y - _paddlePos.y));
            _rb2d.AddForce(new Vector2(_paddleForceX * (_contactPos.y - _paddlePos.y), _paddleForceY * (_contactPos.y - _paddlePos.y)));   // Make the game more challenging/ fun to play

            // Paddle collicion edge radius set to 0.05 to minimize weird edge collisions

        }
        else
        {
            _wallCollision.Play();    // wall collision audio
        }
    }
}
