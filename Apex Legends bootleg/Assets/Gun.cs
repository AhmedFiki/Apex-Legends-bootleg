using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;

    public Transform ShootPoint;
    public float damage;
    public int magAmmo;
    public int magMaxAmmo;
    public int reserveAmmo;
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

    void Start()
    {
        reserveAmmo = GetComponent<Ammo>().primaryAmmo;
        Debug.Log(reserveAmmo);
    }
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

            magAmmo = magMaxAmmo;
            reserveAmmo -= magMaxAmmo;
        }else if (reserveAmmo > 0)
        {
            reloadAudio.Play();

            magAmmo = reserveAmmo;
            reserveAmmo = 0;
        }else
        {
            Debug.Log("No Ammo!");
        }
        
    }
}