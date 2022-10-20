using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public int health;
    public BuildingObject buildingObject;

    private void Start()
    {
        health = buildingObject.health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (buildingObject.hasRubble)
            {
                Instantiate(buildingObject.rubble, gameObject.transform.position, Quaternion.identity, GameObject.Find("Towers").transform);
            }
            Destroy(gameObject);
        }
    }
}
