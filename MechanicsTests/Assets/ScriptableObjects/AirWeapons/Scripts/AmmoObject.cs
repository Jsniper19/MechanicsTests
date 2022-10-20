using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DetonationType
{
    EXPLOSION,
    THUNDER,
    NOTHING
}

[CreateAssetMenu(fileName = "NewAmmoObject", menuName = "ScriptableObject/AirWeapons/New AmmoObject")]
public class AmmoObject : ScriptableObject
{
    [Header("Instansiation Variables")]
    public string ammoName;
    public GameObject WarheadPrefab;

    [Header("Ammunition Variables")]
    public int cooldown;
    public int weight;
    public DetonationType detonationType;
    public GameObject ammo_prefab;
    public int ammo_sizeMax;

    [Header("Penetration Variables")]
    public int penetration_count;
    public int penetration_damage;

    [Header("Explosion Variables")]
    public float explosion_speed;
    public int explosion_damage;
    public bool explosion_isConstant;
    public float explosion_constant_damageSpeed;

    public int detonations;
    public int subDetonations;
    public int detonationsPerLayer;
}