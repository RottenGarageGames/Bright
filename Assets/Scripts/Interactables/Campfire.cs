using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable
{
    public bool On = true;
    public void Interact()
    {
        Debug.Log("interacting");

        if (On)
        {
            var smoke = gameObject.GetComponentInChildren<ParticleSystem>();
            smoke.Stop();
            On = false;
        }
        else
        {
            On = true;
            var smoke = gameObject.GetComponentInChildren<ParticleSystem>();
            smoke.Play();
        }
    }
}
