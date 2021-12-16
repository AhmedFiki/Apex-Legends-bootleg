
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health;
    public Image Healthbar;
    public float MaxHealth;











    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Healthbar.fillAmount = health / MaxHealth;
    }
}
