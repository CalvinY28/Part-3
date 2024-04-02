using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public int score = 0;
    public TMP_Text scoreText;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(IncreaseScore());
        UpdateScoreUI();
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.23f); //Random number to increment increase
            score += 100;
            UpdateScoreUI();
        }
    }
    
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    protected override void FixedUpdate() //Player movement
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Movement direction based on input
        Vector2 movement = new Vector2(Horizontal, Vertical).normalized * moveSpeed; //Use vector 2
        //Move
        rb.position += movement * Time.fixedDeltaTime;
    }
}
