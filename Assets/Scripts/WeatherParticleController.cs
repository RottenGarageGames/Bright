using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherParticleController : ParticleController, IInteractable
{
    public GameObject WeatherFolder;

    void Start()
    {
        SetParticleSystems();
    }
    public void Interact()
    {
        StartEvent();
    }
    public override void SetParticleSystems()
    {
        WeatherFolder = GameObject.Find("Weather");
        ParticleSystems = new List<ParticleSystem>(WeatherFolder.GetComponentsInChildren<ParticleSystem>());
    }
}
