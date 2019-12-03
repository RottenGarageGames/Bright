using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool Active;
    public float RotationChangeInterval;
    public float CurrentTime;
    public float RotationAmount;


    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;

        if(CurrentTime > RotationChangeInterval && Active)
        {
            transform.Rotate(new Vector3(RotationAmount, 0f, 0f));
            CurrentTime = 0f;
        }
    }
}
