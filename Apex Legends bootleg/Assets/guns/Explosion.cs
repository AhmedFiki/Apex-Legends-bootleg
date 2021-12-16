using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource explosionAudio;
    private Collider[] hitColliders;
    public float blastRadius;
    public float explosionForce;
    public GameObject impactExplosion;

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
        Destroy(impactGO, 2f);
        Destroy(gameObject);
        explosionAudio.Play();

    }
    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);

        foreach(Collider hitcol in hitColliders)
        {
            //Debug.Log(hitcol.gameObject.name);
            if (hitcol.GetComponent<Rigidbody>() != null && hitcol.gameObject.name !="FPSController")
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }
            if (hitcol.GetComponent<Target>() != null)
            {
                hitcol.transform.GetComponent<Target>().TakeDamage(25);
            }
            if (hitcol.GetComponent<Player>() != null)
            {
                hitcol.transform.GetComponent<Player>().TakeDamage(25);
            }
        }
    }
}
