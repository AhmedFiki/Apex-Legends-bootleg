using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionFire : MonoBehaviour
{
    public AudioSource explosionAudio;
    public AudioSource impactExplosionAudio;
    private Collider[] hitColliders;
    public float blastRadius;
    public float explosionForce;
    public GameObject impactExplosion;
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;

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
        //Debug.Log(collision.contacts[0].point.ToString());
        DoExplosion(collision.contacts[0].point);
        GameObject impactGO = Instantiate(impactExplosion, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].point));
        GameObject fireground1 = Instantiate(Fire1, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].point));
        GameObject fireground2 = Instantiate(Fire2, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].point));
        GameObject fireground3 = Instantiate(Fire3, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].point));
        explosionAudio.Play();
        impactExplosionAudio.Play();
        //GameObject fireground= Instantiate(Fire, explosionPoint, Quaternion.LookRotation(explosionPoint));

        Destroy(impactGO, 5f);
        Destroy(fireground1, 5f);
        Destroy(fireground2, 5f);
        Destroy(fireground3, 5f);
        Destroy(gameObject);

    }
    void DoExplosion(Vector3 explosionPoint)
    {

                


    }
}
