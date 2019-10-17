using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour
{
    public int health = 10;
    public Text HP;
    public Slider Healthslider;
    public int lives = 2;

    private void Start()
    {
        HP.text = "Health: " + health;
        Healthslider.maxValue = health;
        Healthslider.value = health;
        lives = PlayerPrefs.GetInt("lives");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            HP.text = "Health: " + health;
            Healthslider.value = health;
            if (health < 1)
            { 
                //SceneManager.LoadScene("Victory");
                if (lives > 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    PlayerPrefs.SetInt("lives", lives - 1);
                }
                else
                {
                    SceneManager.LoadScene(7);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Instant")
        {
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}

    
