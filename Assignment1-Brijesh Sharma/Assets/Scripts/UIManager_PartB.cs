using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_PartB : MonoBehaviour
{
    private int _playerScore = 0;
    [SerializeField] private int _gameWinScore = 240; // (number of bricks from BrickFactory) * 10
    private GameObject _ball;
    [SerializeField] public Image[] hearts;
    private int _lives = 3;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _pScore;
    [SerializeField] private AudioSource _winAudio;
    // Start is called before the first frame update
    void Start()
    {

        _ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            MainMenu();
        }

    }

    public void Score()
    {
        _playerScore += 10;
        _pScore.text = _playerScore.ToString();
       
        if (_playerScore >= _gameWinScore)
        {
            _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameOver();
        }
    }

    public void LoseLife()
    {
        _lives--;
        hearts[_lives].gameObject.SetActive(false);
        if (_lives > 0)
        {
            _ball.gameObject.GetComponent<BallBehaviour_PartB>(
            ).Restart();
        }
        else
        {   
            GameOver();
        }

    }

    public void RestartGame()
    {
        _playerScore = 0;
        _lives = 3;
        foreach (Image i in hearts)
        {
            i.gameObject.SetActive(true);
        }
        _pScore.text = _playerScore.ToString();
        _ball.GetComponent<BallBehaviour_PartB>().Restart();
        _gameOverText.gameObject.SetActive(false);
        GameObject.Find("Brick").GetComponent<BrickFactory>().MakeBricks();
    }

    public void GameOver()
    {
        if (_playerScore >= _gameWinScore)
        {
            //_winAudio.Play();
            _gameOverText.text = "YOU WIN!";
            _ball.GetComponent<BallBehaviour_PartB>().ResetBall();
        }
        else
        {
            _gameOverText.text = "GAME OVER";
            _ball.GetComponent<BallBehaviour_PartB>().ResetBall();
        }

        _gameOverText.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
