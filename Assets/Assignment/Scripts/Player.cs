using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public static int score = 0;
    public TMP_Text scoreText;

    public string playAgainScene = "Play Again";

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

    public void ApplySlow(float slowValue)
    {
        moveSpeed *= slowValue;
    }

    public void ApplyNormal(float normalValue)
    {
        moveSpeed = normalValue;
    }

    //I need a static function
    public static int GetScore()
    {
        return score;
    }

    protected override void Die()
    {
        Debug.Log("Score: " + GetScore());
        SceneManager.LoadScene(playAgainScene);
        score = 0;
    }
}
