using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject projectile;
    public float damage;
    public int magAmmo;
    public int magMaxAmmo;
    public int reserveAmmo;
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

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //  projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x + 90, projectile.transform.eulerAngles.y, projectile.transform.eulerAngles.z);
        // grenBarrel.transform.position = new Vector3(grenBarrel.transform.position.x, grenBarrel.transform.position.y, grenBarrel.transform.position.z - 1);
        rb = projectile.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButton("Fire1") && magAmmo > 0)
        {
            Shoot();
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

            magAmmo = magMaxAmmo;
            reserveAmmo -= magMaxAmmo;
        }
        else if (reserveAmmo > 0)
        {
           reloadAudio.Play();

            magAmmo = reserveAmmo;
            reserveAmmo = 0;
        }
        else
        {
            Debug.Log("No Ammo!");
        }
    }
  
}

