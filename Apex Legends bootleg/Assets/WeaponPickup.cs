using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Transform ShootPoint;
    Transform lastPos;

    public GameObject grenade;
    public GameObject flame;
    public GameObject handgrenade;
    public GameObject handflame;



    public GameObject rifle;
    public GameObject sniper;
    public GameObject shotgun;
    public GameObject handrifle;
    public GameObject handsniper;
    public GameObject handshotgun;
    public GameObject nothing;
    public float distance=5f;
    GameObject currentWeapon;
    GameObject currentWeaponSecondary;
    GameObject wp;

    bool canGrab;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = nothing;
        currentWeaponSecondary = nothing;
    }

    void activeWeapon()
    {


        if (currentWeapon == rifle)
        {

            handrifle.SetActive(true);
            handsniper.SetActive(false);
            handshotgun.SetActive(false);

        }
        else if (currentWeapon == sniper)
        {

            handrifle.SetActive(false);
            handsniper.SetActive(true);
            handshotgun.SetActive(false);
        }
        else if (currentWeapon == shotgun)
        {

            handrifle.SetActive(false);
            handsniper.SetActive(false);
            handshotgun.SetActive(true);
        }

        if (currentWeaponSecondary == grenade)
        {

            handgrenade.SetActive(true);
            handflame.SetActive(false);

        }
        else if (currentWeaponSecondary == flame)
        {

            handgrenade.SetActive(false);
            handflame.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
            activeWeapon();





        checkWeapons();
        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(wp.name);
                pickUp(wp.name);
                
            }
        }
    }
    void checkWeapons()
    {
        RaycastHit hit;

        if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit, distance))
        {
            if (hit.transform.tag == "Primary" || hit.transform.tag == "Secondary")
            {
               // Debug.Log("i can grab it");
                canGrab = true;
                wp = hit.transform.gameObject;

            }
        }
        else
        {
            canGrab = false;
           // Debug.Log("cant grab");

        }
       // Debug.Log("check");


    }

    void pickUp(string name)
    {


        if (name.Contains("rifle"))
        {            
            Debug.Log("pick rifle");
            Instantiate(currentWeapon, wp.transform.position, wp.transform.rotation);
            //wp.transform.position = new Vector3(transform.position.x, -5.0f, transform.position.z);
            Destroy(wp);
            currentWeapon = rifle;


        }
        else if (name.Contains("sniper"))
        {
             Debug.Log("pick sniper");

            Instantiate(currentWeapon, wp.transform.position, wp.transform.rotation);
            // wp.transform.position = new Vector3(transform.position.x, -5.0f, transform.position.z);
            Destroy(wp);

            currentWeapon = sniper;

        }
        else if(name.Contains("shotgun"))
        {
            Debug.Log("pick shoogun");
            Instantiate(currentWeapon, wp.transform.position, wp.transform.rotation);
            //wp.transform.position = new Vector3(transform.position.x, -5.0f, transform.position.z);
            Destroy(wp);

            currentWeapon = shotgun;


        }else if (name.Contains("Grenade"))
            {
                Debug.Log("pick grenade launcher");
                Instantiate(currentWeaponSecondary, wp.transform.position, wp.transform.rotation);
                //wp.transform.position = new Vector3(transform.position.x, -5.0f, transform.position.z);
                Destroy(wp);
                currentWeaponSecondary = grenade;


            }
            else if (name.Contains("Flame"))
            {
                Debug.Log("pick flame launcher");

                Instantiate(currentWeaponSecondary, wp.transform.position, wp.transform.rotation);
                // wp.transform.position = new Vector3(transform.position.x, -5.0f, transform.position.z);
                Destroy(wp);

                currentWeaponSecondary = flame;

            }
        }
}
