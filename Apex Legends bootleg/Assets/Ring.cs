using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject Player;
    public CharacterController cc; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log("enter col");

        if (collision.gameObject.name != ("FPSController"))
        {
            Vector3 position = collision.contacts[0].point;
            position.y += 1;
            

            cc.enabled = false;

            Player.gameObject.transform.position = position;
            cc.enabled = true;
            Destroy(gameObject);
        }}

    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    Debug.Log("enter triii");

    //    if (collision.gameObject.name != ("FPSController")) {

    //        cc.enabled = false;

    //        Player.gameObject.transform.position = collision.transform.position;
    //        cc.enabled = true;


    //       /*Vector3 position = collision.gameObject.transform.position;
    //        position.y += 5;
    //        collision.gameObject.transform.position = position;

    //        Player.SetActive(false);



    //        Player.transform.position = collision.gameObject.transform.position;
    //        Player.SetActive(true);*/

    //        Destroy(gameObject);}

    //}


    void DoTeleport()
    {





    }
}
