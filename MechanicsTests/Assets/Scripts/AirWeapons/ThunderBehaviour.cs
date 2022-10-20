using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBehaviour : MonoBehaviour
{
    public AmmoObject ammoObject;

    private Collider[] collisions;
    [SerializeField] private List<Collider> collision = new List<Collider>();
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask layerMask;
    public int strikeCount;

    public float killTime = 1;
    public float killTimer;

    // Start is called before the first frame update
    void Start()
    {
        GetStrikes();
        CreateStrikes();
    }

    private void GetStrikes()
    {
        collisions = Physics.OverlapSphere(gameObject.transform.position, ammoObject.ammo_sizeMax, layerMask);
        collision.AddRange(collisions);
        foreach (Collider target in collision)
        {
            if (target.transform.position == gameObject.transform.position)
            {
                collision.Remove(target);
                break;
            }
        }
        if (collision.Count > 0)
        {
            target = collision[Random.Range(0, collision.Count)].transform;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateStrikes()
    {
        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, target.GetComponent<Renderer>().bounds.center);

        target.GetComponent<DestructableObject>().health -= ammoObject.explosion_damage;

        if (strikeCount < ammoObject.subDetonations)
        {
            for (int i = 0; i < ammoObject.detonationsPerLayer; i++)
            {
                GameObject childStrikeGO = Instantiate(ammoObject.ammo_prefab, target.GetComponent<Renderer>().bounds.center, Quaternion.identity);
                ThunderBehaviour childThunder = childStrikeGO.GetComponent<ThunderBehaviour>();
                childThunder.strikeCount++;
                childThunder.ammoObject = ammoObject;
            }
        }
    }

    private void Update()
    {
        if (killTimer >= killTime)
        {
            Destroy(gameObject);
        }
        else
        {
            killTimer += Time.deltaTime;
        }
    }
}
