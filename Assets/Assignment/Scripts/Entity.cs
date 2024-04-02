using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float maxHealth = 5;
    protected float currentHealth;
    protected Rigidbody2D rb;
    public Slider healthSlider; //Make sure public
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ow");
            TakeDamage(1f);
        }
    }

    protected virtual void FixedUpdate()
    {
        //float Horizontal = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis("Vertical");

        //Movement direction based on input
        //Vector2 movement = new Vector2(Horizontal, Vertical).normalized * moveSpeed; //Use vector 2

        //Move
        //rb.position += movement * Time.fixedDeltaTime;

    }

    public virtual void TakeDamage(float damage) //Public to allow overide in childs
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        Debug.Log("Player died!");
    }

    protected virtual void UpdateHealthUI()
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