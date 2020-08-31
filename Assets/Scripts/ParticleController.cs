using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleController : MonoBehaviour
{
    public List<ParticleSystem> ParticleSystems;
    public ParticleEvent ParticleEv;
    public float DefaultGravity = .47f;

    public abstract void SetParticleSystems();

    [Header("Particle Size")]
    [Space(5)]
    public float maxSize;
    public float minSize;
    public float SizeChangeRate;

    [Header("Color Variables")]
    [Space(5)]
    public float HueMin;
    public float HueMax;
    public float SaturationMin;
    public float SaturationMax;
    public float ValueMin;
    public float ValueMax;

    public enum ParticleEvent
    {
        ChangePlayMode,
        RandomColor,
        IncreaseEffectSize,
        DecreaseEffectSize, 
        FlipGravity,
    }
    public void StartEvent()
    {
        switch (ParticleEv)
        {
            case ParticleEvent.ChangePlayMode:
                ChangePlayMode(ParticleSystems);
                break;
            case ParticleEvent.RandomColor:
                AssignRandomColor(ParticleSystems);
                break;
            case ParticleEvent.IncreaseEffectSize:
                IncreaseSize(ParticleSystems);
                break;
            case ParticleEvent.DecreaseEffectSize:
                DecreaseSize(ParticleSystems);
                break;
            case ParticleEvent.FlipGravity:
                FlipGravity(ParticleSystems);
                break;
            default:
                StartEvent(EnumHelper.RandomEnumValue<ParticleEvent>());
                break;
        }
    }
    public void StartEvent(ParticleEvent particleEvent)
    {
        ParticleEv = particleEvent;
        StartEvent();
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

            if (main.startSize.constant + SizeChangeRate > maxSize)
            {
                main.startSize = maxSize;
            }
            else
            {
                main.startSize = main.startSize.constant + SizeChangeRate;
            }
        }
    }
    private void DecreaseSize(List<ParticleSystem> particleSystems)
    {
        foreach (var item in particleSystems)
        {
            ParticleSystem.MainModule main = item.main;

            if (main.startSize.constant - minSize < minSize)
            {
                main.startSize = minSize;
            }
            else
            {
                main.startSize = main.startSize.constant - SizeChangeRate;
            }
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
    public void SetParticleSizeFromFloat(float maxParticleSize)
    {
        foreach (var item in ParticleSystems)
        {
            ParticleSystem.MainModule main = item.main;

            var newValue = maxSize * (maxParticleSize / 100);

            if (newValue > maxSize)
            {
                main.startSize = maxSize;
            }
            else
            {
                main.startSize = maxSize * (maxParticleSize / 100);
            }
        }
    }
}
