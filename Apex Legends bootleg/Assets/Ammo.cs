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

    // Start is called before the first frame update
    void Start()
    {
        primaryAmmo = 69;
        secondaryAmmo = 5;
         primaryText.text = primaryAmmo.ToString();
        SecondaryText.text = secondaryAmmo.ToString();
}

    // Update is called once per frame
    void Update()
    {

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

    {

        if (collision.gameObject.CompareTag("PrimaryAmmo"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked Primary Ammo");

                primaryPickup();
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("SecondaryAmmo"))
        {
            if (Input.GetKeyDown(KeyCode.E)){     
                Debug.Log("Picked Secondary Ammo");

                secondaryPickup();
                Destroy(collision.gameObject);
            }
        }
    }




}
