using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject primary;
    public GameObject secondary;
    private bool b=true;
    // Start is called before the first frame update
    void Start()
    {
        primary.SetActive(b);
        secondary.SetActive(!b);
    }

    // Update is called once per frame
    void Update()
    {
        primary.SetActive(b);
        secondary.SetActive(!b);

        if (Input.GetKeyDown(KeyCode.Z) )
        {
            b = !b;   
        }
    }
   
    }

