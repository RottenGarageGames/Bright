using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable
{
    public ParticleSystem Smoke;
    public string SmokeGameObjectName;
    public bool On = true;
    public CampfireParticleController CampfireParticleController;
    public float MaxFuel;
    public float Fuel;
    public float FuelTimer;
    public float FuelTimerDefaultValue;
    public float FuelLossRate;

    public ItemTaker ItemTaker;

    private void Start()
    {
        Smoke = gameObject.GetComponentsInChildren<ParticleSystem>().Where(x => x.name == SmokeGameObjectName).FirstOrDefault();
        CampfireParticleController = gameObject.GetComponent<CampfireParticleController>();
        ItemTaker = gameObject.GetComponent<ItemTaker>();
    }
    private void Update()
    {

        if (On)
        {
            FuelTimer -= Time.deltaTime;
            if (FuelTimer <= 0)
            {
                FuelTimer = FuelTimerDefaultValue;
                Fuel -= FuelLossRate;
                CampfireParticleController.SetParticleSizeFromFloat(Fuel);
            }
        }

        if (Fuel <= 0 && On)
        {
            DisableFire();
        }

    }
    public void ActivateFire()
    {
      On = true;
      Smoke.Play();
    }
    private void DisableFire()
    {
        Smoke.Stop();
        On = false;
    }

    public void Interact(GameObject interactingObject)
    {
        if (Fuel < MaxFuel)
        {
            var interactingInv = interactingObject.GetComponentInChildren<Inventory>();
            if (ItemTaker.TakeItems(interactingInv))
            {

                AddFuel(20f);
                if (!On)
                {
                    ActivateFire();
                }
            }
        }
    }
    public void AddFuel(float fuelAmount)
    {
        Fuel += fuelAmount;
        CampfireParticleController.SetParticleSizeFromFloat(Fuel);
    }
}
