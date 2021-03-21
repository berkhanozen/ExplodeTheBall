using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D physics;
    float speed = 15;
    public int score { get; private set; }
    public int highscore { get; private set; }
    public Text scoreText, highscoreText;
    public GameObject player;
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        GetHighScore();
    }

    void Update()
    {
        Invoke("BallMove", 2f);
        float posy = player.transform.position.y;
        if(posy >= 1f)
        {
            player.transform.position = new Vector2(player.transform.position.x, -6.4f);
        }
    }

    void BallMove()
    {
        physics.velocity = new Vector3(1, 0, 0) * speed;
    }

    private void GetHighScore()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = "Score: 0";
        if (SceneManager.GetActiveScene().name.Equals("NewGameScene"))
        {
            highscore = 0;
            highscoreText.text = "HighScore: " + highscore;
        }
        else if(SceneManager.GetActiveScene().name.Equals("LoadLastGameScene"))
        {
            highscoreText.text = "HighScore: " + highscore.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().Play();
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();
        if (tagManager == null)
            return;
        Tag tag = tagManager.myTag;
        if(tag.Equals(Tag.wall))
        {
            speed *= -1;
        }
        if(tag.Equals(Tag.bomb))
        {
            targetHit();
        }
    }
    void targetHit()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        if(score > highscore)
        {
            highscore = score;
            highscoreText.text = "HighScore: " + highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
        }
        float posy = player.transform.position.y;
        if (score != 0 && score % 5 == 0)
        {
            posy++;
            player.transform.position = new Vector2(player.transform.position.x, posy);
        }
    }
}
