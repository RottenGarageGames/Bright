using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterColors : MonoBehaviour
{
   public Color StartColor;
   public Color EndColor;
   public float TransitionTime;
   Light Light;

    private void Start()
    {
        Light = gameObject.GetComponent<Light>();
    }

    private void Update()
    {
        Light.color = Color.Lerp(StartColor, EndColor, Mathf.PingPong(Time.time, TransitionTime));
    }
}
