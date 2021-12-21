using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   

    public float health;
    public Image Healthbar;
    public float MaxHealth;
    public Text HealthText;

  

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health/MaxHealth);
        Healthbar.fillAmount = health / MaxHealth;
        HealthText.text = health.ToString() + "%";

        if (health > 100)
            health = 100;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        Healthbar.fillAmount = health / MaxHealth;
        if (health <= 0)
        {
            Die();
        }
    }
    public void healthPickup()
    {
        
        health += 25; 
        Healthbar.fillAmount = health / MaxHealth;
    }
    public void Die()
    {
        Debug.Log("DEAD!");
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            if (Input.GetKeyDown(KeyCode.E)) { 
            healthPickup();
            Destroy(collision.gameObject);
            }

        }
    }
}
