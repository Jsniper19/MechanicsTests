using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidController : MonoBehaviour
{
    public float speedMax;
    public float speedCurrent;
    public int jumpsTotal;
    public int jumpsRemaining;
    public bool isGrounded;
    public int healthMax;
    public int healthCurrent;

    private void OnEnable()
    {
        healthCurrent = healthMax;
        speedCurrent = 0;
        jumpsRemaining = jumpsTotal;
        isGrounded = true;
    }
}
