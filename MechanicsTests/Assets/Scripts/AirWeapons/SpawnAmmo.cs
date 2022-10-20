using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour
{
    public List<AmmoObject> ammoList = new List<AmmoObject>();

    public Transform bulletSpawn;

    public void Fire(string RequestedAmmo)
    {
        foreach (AmmoObject ammoType in ammoList)
        {
            if (RequestedAmmo == ammoType.ammoName)
            {
                GameObject currentBullet = Instantiate(ammoType.WarheadPrefab, bulletSpawn.position, Quaternion.identity);
                currentBullet.GetComponent<AmmoController>().ammoObject = ammoType;
                break;
            }
        }
    }

}
