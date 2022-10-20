using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingObject", menuName = "ScriptableObject/AirWeapons/New BuildingObject")]

public class BuildingObject : ScriptableObject
{
    public int health;
    public GameObject rubble;
    public bool hasRubble;
}
