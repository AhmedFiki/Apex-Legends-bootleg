using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    public int primaryAmmo;
    public int secondaryAmmo;
    public Text primaryText;
    public Text SecondaryText;
    public Text notificationText;
    private bool inside=false;

    // Start is called before the first frame update
    void Start()
    {
        primaryAmmo = 150;
        secondaryAmmo = 5;
         primaryText.text = primaryAmmo.ToString();
        SecondaryText.text = secondaryAmmo.ToString();
        notificationText.text = "";
}

    // Update is called once per frame
    void Update()
    {
        if(!inside)
            notificationText.text = "";

        primaryText.text = primaryAmmo.ToString();
        SecondaryText.text = secondaryAmmo.ToString();

        if (primaryAmmo > 150)
            primaryAmmo = 150;

        if (primaryAmmo < 0)
            primaryAmmo = 0;

        if (secondaryAmmo > 5)
            secondaryAmmo = 5;

        if (secondaryAmmo < 0)
            secondaryAmmo = 0;
    }

    public void addAmmo(bool type,int amount)
    {
        if (type)
        {
            primaryAmmo += amount;

        }
        else
        {
            secondaryAmmo += amount;
        }
    }
    public void subtractAmmo(bool type, int amount)
    {
        if (type)
        {
            primaryAmmo -= amount;
        }
        else
        {
            secondaryAmmo -= amount;

        }
    }

    public int showPrimary()
    {
        return primaryAmmo;
    } 
    public int showSecondary()
    {
        return secondaryAmmo;
    }

    public void primaryPickup()
    {
        addAmmo(true, 50);
    }
    public void secondaryPickup()
    {
        addAmmo(false, 2);
    }
    
    


    private void OnTriggerStay(Collider collision)

    {                GameObject amm = collision.gameObject;


        if (collision.gameObject.CompareTag("PrimaryAmmo"))
        {        inside= true;

            notificationText.text = "Press 'E' to pickup Primary Ammo";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked Primary Ammo");

                primaryPickup();
                Destroy(amm);
                notificationText.text = "";
            }

        }
        if (collision.gameObject.CompareTag("SecondaryAmmo"))
        {
            inside= true;

            notificationText.text = "Press 'E' to pickup Secondary Ammo";

            if (Input.GetKeyDown(KeyCode.E)){     
                Debug.Log("Picked Secondary Ammo");

                secondaryPickup();
                Destroy(amm);
                notificationText.text = "";

            }
        }
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            inside = true;

            notificationText.text = "Press 'E' to pickup MedKit";

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked MedKit");

                gameObject.GetComponent<Player>().healthPickup();
                Destroy(amm);
                notificationText.text = "";
            }

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("PrimaryAmmo") || collision.gameObject.CompareTag("SecondaryAmmo")|| collision.gameObject.CompareTag("HealthPickup"))
        {

            inside = false;


        }
        }




}
