using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Launcher : MonoBehaviour
{
    public GameObject projectile;
    public float damage;
    public int magAmmo;
    public int magMaxAmmo;
    public Text magMaxText;
    public Text MagText;
    private int reserveAmmo;
    private float nextfire = 0;
    public float propForce;
    public float rateOfFire;
    private float nextFire;

    public ParticleSystem muzzleFlash;
   // public GameObject impactExplosion;
    //public GameObject impactSand;
    public AudioSource shootAudio;
    public AudioSource reloadAudio;
    public Transform grenBarrel;
    public GameObject player;

    public Animator gunAnimator;
    private bool isShooting = false;




    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        reserveAmmo = player.GetComponent<Ammo>().showSecondary();

        MagText.text = magAmmo.ToString();
        magMaxText.text = magMaxAmmo.ToString();
       
        rb = projectile.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        reserveAmmo = player.GetComponent<Ammo>().showSecondary();
        gunAnimator.SetBool("Shoot", isShooting);

        MagText.text = magAmmo.ToString();
        magMaxText.text = magMaxAmmo.ToString();

        if (Input.GetMouseButtonDown(0) && magAmmo > 0)
        {
            isShooting = true;
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }


    
    void Shoot()
    {
        if (Time.time > nextFire && magAmmo>0)
        {       GameObject gren = Instantiate(projectile, grenBarrel.position,grenBarrel.transform.rotation );
                           gren.GetComponent<Rigidbody>().AddForce(grenBarrel.up * propForce, ForceMode.Impulse);
            nextFire = Time.time + rateOfFire;
            shootAudio.Play();
            muzzleFlash.Play();
            magAmmo--;

            
                

           
           Destroy(gren,6f);   

        }
    }
    void Reload()
    {
        if (reserveAmmo >= magMaxAmmo)
        {
            reloadAudio.Play();
            player.GetComponent<Ammo>().addAmmo(false, magAmmo);

            magAmmo = magMaxAmmo;
            reserveAmmo -= magMaxAmmo;
            player.GetComponent<Ammo>().subtractAmmo(false, magMaxAmmo);
        }
        else if (reserveAmmo > 0)
        {
            int curr = magMaxAmmo - magAmmo;
            if (reserveAmmo > curr)
            {
                reserveAmmo -= curr;
                magAmmo = magMaxAmmo;
                player.GetComponent<Ammo>().subtractAmmo(false, curr);

            }
            else
            {
                player.GetComponent<Ammo>().subtractAmmo(false, reserveAmmo);
                magAmmo = magAmmo + reserveAmmo;

                reserveAmmo = 0;

            }
            reloadAudio.Play();



        }
        else
        {
            Debug.Log("No Ammo!");
        }

    }

}

