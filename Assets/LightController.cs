using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] float MaxRadius;
    [SerializeField] Light Light;

    private void Start()
    {
       Light = gameObject.GetComponent<Light>();
    }

    public void SetLightRadius(float percentage)
    {
        Light.range = percentage * MaxRadius;
    }
}
