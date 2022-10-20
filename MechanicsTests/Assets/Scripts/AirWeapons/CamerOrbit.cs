using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerOrbit : MonoBehaviour
{
    public CinemachineVirtualCamera CMVC;
    private CinemachineOrbitalTransposer CMOT;
    [Tooltip("How many seconds it takes for a full rotation")]public float rotationTime;

    private void Start()
    {
        CMOT = CMVC.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    private void Update()
    {
        if (CMOT.m_Heading.m_Bias != 180)
        {
            CMOT.m_Heading.m_Bias += Time.deltaTime * 360 / rotationTime;
        }
        else
        {
            CMOT.m_Heading.m_Bias = -180;
        }
    }
}
