using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
{
    private bool onfire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!onfire) { Debug.Log(collision.name);

                onfire = true;
                if (collision.gameObject.GetComponent<Target>() != null)
                    collision.gameObject.GetComponent<Target>().TakeDamage(25);
                if (collision.gameObject.GetComponent<Player>() != null)
                    collision.gameObject.GetComponent<Player>().TakeDamage(25);
                StartCoroutine(onFire());
            }
        }


        IEnumerator onFire()
        {

            yield return new WaitForSeconds(1);
            onfire = false;
        } }
