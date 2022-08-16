using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private int currentHealth;


   
    private Vector2 healthBarOriginalSize;
    private Rigidbody2D rb;
    private readonly float collissionForce = 10.0f;
    
    public Color color;
    public float colorAlpha;

    //constrain Player max health to 100
    private int maxHealth = 100;
   

    void Start()
    {
        currentHealth = maxHealth;
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
        rb = GetComponent<Rigidbody2D>();           
    }

     void Update()
    {
        Die();
        UpdateUI();
        
    }

    // Update is called once per frame
    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Olteanu Scene");
        }
    }
    public void UpdateUI()
    {
        float healthBarSize = healthBarOriginalSize.x * ((float)currentHealth / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize, healthBar.rectTransform.sizeDelta.y);
    }

    public void PlayerHurt(int damage)
    {
        
          currentHealth -= damage;
            rb.velocity = new Vector2(-1, 1) * collissionForce;
            StartCoroutine(ResetVelocityCoroutine());
        
    }
    IEnumerator ResetVelocityCoroutine()
    {
        yield return new WaitForSeconds(0.10f);
        rb.velocity = Vector2.zero;
    }

    public void HealthBarActive(bool isActive)
    {
      //  canTakeDamage = isActive;
       // healthBar.color = color;
    }
}
