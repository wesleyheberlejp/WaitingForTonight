using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlharParaACamera_Comportamento : MonoBehaviour
{
    public Camera Camera;
    public float TimerFrequencia = 0.5f;
    public float TempTimerFrequencia;

    private void Awake()
    {
        TempTimerFrequencia = TimerFrequencia;

        if (Camera == null)
        {
            Camera = Camera.main;
        }
    }

    void FixedUpdate()
    {
        if (TimerFrequencia > 0) TempTimerFrequencia -= Time.fixedDeltaTime;

        if(TempTimerFrequencia < 0)
        {
            transform.LookAt(Camera.transform);
            TempTimerFrequencia = TimerFrequencia;
        }
    }
}
