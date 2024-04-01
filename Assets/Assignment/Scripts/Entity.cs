using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public float moveSpeed = 5;
    public float maxHealth = 5;
    private float currentHealth;
    private Rigidbody2D rb;
    public Slider healthSlider; //Make sure public
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ow");
            TakeDamage(1f);
        }
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Movement direction based on input
        Vector2 movement = new Vector2(Horizontal, Vertical).normalized * moveSpeed; //Use vector 2

        //Move
        rb.position += movement * Time.fixedDeltaTime;

    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Player died!");
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
            if (currentHealth <= 2) //Change color when health is low
            {
                healthSlider.fillRect.GetComponent<Image>().color = lowHealthColor;
            }
            else
            {
                healthSlider.fillRect.GetComponent<Image>().color = fullHealthColor;
            }
        }
    }

}