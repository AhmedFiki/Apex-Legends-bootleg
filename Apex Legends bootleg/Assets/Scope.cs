using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    private bool isScoped = false;
    public GameObject weaponCamera;
    public Camera mainCam;
    public float scopedFOV = 15f;
    private float normalFOV;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);


            if (gameObject.GetComponent<WeaponPickup>().currentWeapon == gameObject.GetComponent<WeaponPickup>().sniper)
            {
                if (isScoped)
                    StartCoroutine(onScoped());
                else
                    onUnscoped();
            }
        }    
    }


    void onUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCam.fieldOfView = normalFOV;
    }
    IEnumerator onScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        normalFOV = mainCam.fieldOfView;
        mainCam.fieldOfView = scopedFOV;
    }
}
