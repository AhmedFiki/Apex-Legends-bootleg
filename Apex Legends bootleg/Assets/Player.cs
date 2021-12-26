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
    public int specialPoints=100;
    public Image Specialbar;
    public GameObject Specialbarfull;
    private float MaxSpecial=100;
    public Text SpecialText;
    private bool inside = false;
    public GameObject ring;
   // public GameObject shield;
    public float ringForce;
    public GameObject leftHand;
    public AudioSource ping;
    public bool invincible=false;
    public string currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //specialPoints = 0;
        StartCoroutine(specialTimer());

    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = health / MaxHealth;
        Specialbar.fillAmount = specialPoints / MaxSpecial;
        HealthText.text = health.ToString() + "%";
        SpecialText.text = specialPoints.ToString();

        if (health > 100)
            health = 100;
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        if (specialPoints >= 100)
        {
            specialPoints = 100;
            Specialbarfull.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (currentCharacter.Equals("loba"))
            {
            lobaUlt();

            }
            else
            {
            bangUlt();
            }

            //specialPoints = 0;
            //Specialbarfull.SetActive(false);

            //DoUltimate();
        }
    }
    public void TakeDamage(float amount)
    {
        if (!invincible) 
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
  
    
    IEnumerator specialTimer()
    {
        if(specialPoints<100)
            specialPoints += 1;
        
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(specialTimer());
    }

    public void lobaUlt()
    {
        ping.Play();
        GameObject projectile = Instantiate(ring, leftHand.transform.position, leftHand.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(leftHand.transform.up * ringForce, ForceMode.Impulse);
    }
    public void bangUlt()
    {
        StartCoroutine(invincibleTimer());
    }
    IEnumerator invincibleTimer()
    {
        invincible = true;
        yield return new WaitForSeconds(10f);
        invincible = false;


    }

}
