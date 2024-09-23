//Elisa Reyes
// 9-22-24
//This file handles the status of the game and how the player interacts with the

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text timerText;
    public Text winText;
    public Text loseText;
    public Button restartButton;
    float timer = 60f;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        seconds = 60;
        winText.text = "";
        restartButton.gameObject.SetActive(false);
        timerText.text = "Timer: " + seconds.ToString();
        loseText.text = "";
    }

    // FixedUpdate is in sync with physics engine
    void FixedUpdate()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector2 movement = new Vector2(moveHorizontal, moveVertical);
       rb2d.velocity = movement * speed;
    }

    //Displays "Game over" message when the player hits the pickup object
    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            loseText.text = "Game Over";
        }
    }

    void Update()
    {
        //counts down the seconds
        timer -= Time.deltaTime;
        seconds = (int)timer % 60;
       
            
        timerText.text = "Timer: " + seconds.ToString();
        
        //displays "win" message and restart button when timer hits 0
        if (seconds == 0) {
            winText.text = "You Win!";
            restartButton.gameObject.SetActive(true);
        }
    }

    public void onRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene"); //restart game
    }
}
