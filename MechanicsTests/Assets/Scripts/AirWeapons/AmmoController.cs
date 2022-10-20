using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoController : MonoBehaviour
{
    public AmmoObject ammoObject;
    [SerializeField] private Collider col;
    private int penetrationsLeft;

    private void Start()
    {
        penetrationsLeft = ammoObject.penetration_count;
        col.isTrigger = true;
    }

    private void Update()
    {
        if (penetrationsLeft <= 0)
        {
            col.isTrigger = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DestructableObject>())
        {
            other.GetComponent<DestructableObject>().health -= ammoObject.penetration_damage;
        }
        penetrationsLeft--;
        if (other.CompareTag("ground"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(-rb.velocity * 1.5f, ForceMode.VelocityChange);
            penetrationsLeft = 0;
        }
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(ammoObject.detonationType)
        {
            case DetonationType.EXPLOSION:
                {
                    Explosion();
                    break;
                }
            case DetonationType.THUNDER:
                {
                    Thunder();
                    break;
                }
            case DetonationType.NOTHING:
                {
                    break;
                }
        }
    }

    //Event Triggered Custom Functions
    public void Explosion()
    {
        GameObject explosion = Instantiate(ammoObject.ammo_prefab, gameObject.transform.position, Quaternion.identity);
        explosion.GetComponent<ExplosionBehaviour>().ammoObject = ammoObject;
        Destroy(gameObject);
    }

    public void Thunder()
    {
        for (int i = 0; i < ammoObject.detonations; i++)
        {
            GameObject Thunder = Instantiate(ammoObject.ammo_prefab, gameObject.transform.position, Quaternion.identity);
            Thunder.GetComponent<ThunderBehaviour>().ammoObject = ammoObject;
        }
        Destroy(gameObject);
    }
}