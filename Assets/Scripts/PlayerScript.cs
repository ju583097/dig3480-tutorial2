using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public Text score;
    public Text lives;
    private int scoreValue = 0;
    private int livesValue = 3;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        lives.text = livesValue.ToString();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

         
                 lives.text = "Lives: " + livesValue.ToString();


        if(scoreValue >=4)
        {
            winTextObject.SetActive(true);
        }
        if(livesValue <=0)
        {
            loseTextObject.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if(collision.collider.tag == "Enemy")
        {
           livesValue -= 1;
           lives.text = livesValue.ToString();
           Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    void LateUpdate()
    {
        if(scoreValue == 0)
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
        if(scoreValue == 4)
        {
            musicSource.clip = musicClipOne;
            musicSource.Stop();
        }
        if(scoreValue == 4)
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
    }

  
}
