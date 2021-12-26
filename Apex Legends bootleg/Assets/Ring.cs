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


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name != ("FPSController")) {

            cc.enabled = false;

            Player.gameObject.transform.position = collision.transform.position;
            cc.enabled = true;


           /*Vector3 position = collision.gameObject.transform.position;
            position.y += 5;
            collision.gameObject.transform.position = position;

            Player.SetActive(false);



            Player.transform.position = collision.gameObject.transform.position;
            Player.SetActive(true);*/

            Destroy(gameObject);}

    }


    void DoTeleport()
    {





    }
}
