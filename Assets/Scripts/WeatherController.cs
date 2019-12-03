using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour, IInteractable
{
    public GameObject WeatherFolder;
    public WeatherEvents WeatherEvent;
    public float DefaultGravity = .47f;
    public float SizeChangeRate;
    public float HueMin;
    public float HueMax;
    public float SaturationMin;
    public float SaturationMax;
    public float ValueMin;
    public float ValueMax;

    public enum WeatherEvents { ChangePlayMode, RandomColor, IncreaseEffectSize, DecreaseEffectSize, FlipGravity}

    void Start()
    {
        WeatherFolder = GameObject.Find("Weather");
    }
    public void Interact()
    {
        StartEvent(WeatherEvent);
    }
    private void StartEvent(WeatherEvents weatherEvent)
    {
        var particleEffects = new List<ParticleSystem>(WeatherFolder.GetComponentsInChildren<ParticleSystem>());
        switch (WeatherEvent)
        {
            case WeatherEvents.ChangePlayMode:
                ChangePlayMode(particleEffects);
                break;
            case WeatherEvents.RandomColor:
                AssignRandomColor(particleEffects);
                break;
            case WeatherEvents.IncreaseEffectSize:
                IncreaseSize(particleEffects);
                break;
            case WeatherEvents.DecreaseEffectSize:
                DecreaseSize(particleEffects);
                break;
            case WeatherEvents.FlipGravity:
                FlipGravity(particleEffects);
                break;
            default:
                StartEvent(EnumHelper.RandomEnumValue<WeatherEvents>());
                break;
        }
    }
    private void ChangePlayMode(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            if (item.isPlaying)
            {
                item.Pause();
            }
            else
            {
                item.Play();
            }
        }
    }
    private void AssignRandomColor(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            ParticleSystem.MainModule main = item.main;
            main.startColor = UnityEngine.Random.ColorHSV(HueMin, HueMax, SaturationMin, SaturationMax, ValueMin, ValueMax);
        }
    }
    private void IncreaseSize(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            ParticleSystem.MainModule main = item.main;
            main.startSize = main.startSize.constant + SizeChangeRate;
        }
    }
    private void DecreaseSize(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            ParticleSystem.MainModule main = item.main;
            main.startSize = main.startSize.constant - SizeChangeRate;
        }
    }
    private void FlipGravity(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            
            ParticleSystem.MainModule main = item.main;
            var newGravity = main.gravityModifier.constant * -1f;
            main.gravityModifier = newGravity;
            
        }
    }
}
