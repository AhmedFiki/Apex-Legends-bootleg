using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    RaycastHit hit;

    public Transform ShootPoint;
    public float damage;
    public int magAmmo;
    public int magMaxAmmo;
    private int reserveAmmo;
    public Text magMaxText;
    public Text MagText;
    public float impactForce=60f;
    //Rate Of Fire
    public float rateOfFire;
    private float nextfire = 0;

    public float weaponRange;
    private float nextFire;
    public ParticleSystem muzzleFlash;
    public GameObject impactMetal;
    public GameObject impactSand;
    public AudioSource shootAudio;
    public AudioSource reloadAudio;
    public GameObject player;

    void Start()
    {
        reserveAmmo = player.GetComponent<Ammo>().showPrimary();
        Debug.Log(reserveAmmo);

        MagText.text = magAmmo.ToString();
        magMaxText.text = magMaxAmmo.ToString();
    }
        void Update()
    {
        reserveAmmo = player.GetComponent<Ammo>().showPrimary();

        MagText.text = magAmmo.ToString();
        magMaxText.text = magMaxAmmo.ToString();

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
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            shootAudio.Play();
            muzzleFlash.Play();
            magAmmo--;



            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit, weaponRange))
            {
                Debug.Log(hit.transform.name);
              Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal*impactForce);
                }
                GameObject impactGO=Instantiate(impactMetal, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 5f);
                GameObject impactGO2=Instantiate(impactSand, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO2, 5f);
            }
        }
    }
    void Reload()
    {
        if (reserveAmmo >= magMaxAmmo)
        {
            reloadAudio.Play();
            player.GetComponent<Ammo>().addAmmo(true, magAmmo);

            magAmmo = magMaxAmmo;
            reserveAmmo -= magMaxAmmo;
            player.GetComponent<Ammo>().subtractAmmo(true, magMaxAmmo);
        }else if (reserveAmmo > 0)
        {
            int curr = magMaxAmmo - magAmmo;
            if (reserveAmmo > curr)
            {
                reserveAmmo -= curr;
                magAmmo = magMaxAmmo;
                player.GetComponent<Ammo>().subtractAmmo(true, curr);

            }
            else
            {               
                player.GetComponent<Ammo>().subtractAmmo(true, reserveAmmo);  
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