using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionFire : MonoBehaviour
{
    public AudioSource explosionAudio;
    private Collider[] hitColliders;
    public float blastRadius;
    public float explosionForce;
    public GameObject impactExplosion;
    public GameObject Fire;

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
        GameObject impactGO = Instantiate(impactExplosion, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
        Destroy(impactGO, 4f);
        Destroy(gameObject);
        explosionAudio.Play();

    }
    void DoExplosion(Vector3 explosionPoint)
    {
      GameObject fireground= Instantiate(Fire, explosionPoint, Quaternion.LookRotation(explosionPoint));

    }
}
