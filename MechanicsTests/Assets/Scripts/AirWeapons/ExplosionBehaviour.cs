using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [HideInInspector] public AmmoObject ammoObject;
    private float explosion_speed;
    private float explosion_constant_time;

    private void Start()
    {
        explosion_speed = ammoObject.explosion_speed * Time.deltaTime;
    }

    private void Update()
    {
        if (transform.localScale.magnitude < Vector3.one.magnitude * ammoObject.ammo_sizeMax)
        {
            transform.localScale = new Vector3(transform.localScale.x + explosion_speed, transform.localScale.y + explosion_speed, transform.localScale.z + explosion_speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!ammoObject.explosion_isConstant)
        {
            if (collision.gameObject.GetComponent<DestructableObject>())
            {
                collision.gameObject.GetComponent<DestructableObject>().health -= ammoObject.explosion_damage;
            }
            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.position - gameObject.transform.position, ForceMode.Force);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (ammoObject.explosion_isConstant)
        {
            if (collision.gameObject.GetComponent<DestructableObject>())
            {
                if (explosion_constant_time < ammoObject.explosion_constant_damageSpeed)
                {
                    explosion_constant_time += Time.deltaTime;
                }
                else
                {
                    collision.gameObject.GetComponent<DestructableObject>().health -= ammoObject.explosion_damage;
                    explosion_constant_time = 0;
                }
            }
            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.position - gameObject.transform.position, ForceMode.Force);
            }
        }
    }
}
