using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private int health;


    public int Health { get => health; set => health = value; }
    private Vector2 healthBarOriginalSize;
       
      

    //constrain Player max health to 100
    private int maxHealth = 100;
    

    void Start()
    {
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
        
        
        
    }
     void Update()
    {
        Die();
        UpdateUI();
        
    }

    // Update is called once per frame
    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Olteanu Scene");
        }
    }
    public void UpdateUI()
    {
        float healthBarSize = healthBarOriginalSize.x * ((float)Health / (float)maxHealth);
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize, healthBar.rectTransform.sizeDelta.y);
    }

    public void PlayerHurt(int damage)
    {
        health -= damage;
                

    }
    public void HealthBarActive(bool isActive)
    {
        
        if (!isActive)
        {
            healthBar.color = Color.clear;
        }
        else
        {
            healthBar.color = Color.cyan;
        }
        
    }
}
