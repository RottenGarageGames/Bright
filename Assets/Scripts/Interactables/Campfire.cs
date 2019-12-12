using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable
{
    [SerializeField] ParticleSystem _smoke;
    [SerializeField] string _smokeGameObjectName;
    [SerializeField] bool On = true;
    [SerializeField] CampfireParticleController _campfireParticleController;
    [SerializeField] float _maxFuel;
    [SerializeField] float _fuel;
    [SerializeField] ItemTaker _itemTaker;
    [SerializeField] LightController _flameLightController;
    [SerializeField] float _fuelAddAmount;

    private void Start()
    {
        _smoke = gameObject.GetComponentsInChildren<ParticleSystem>().Where(x => x.name == _smokeGameObjectName).FirstOrDefault();
        _campfireParticleController = gameObject.GetComponent<CampfireParticleController>();
        _itemTaker = gameObject.GetComponent<ItemTaker>();
        _flameLightController = gameObject.GetComponentInChildren<LightController>();
    }
    private void Update()
    {

        if (On)
        {
            if (_fuel > 0)
            {
                _fuel -= Time.deltaTime;
                _campfireParticleController.SetParticleSizeFromFloat(_fuel);
            }

            UpdateLightRadius();
        }

        if (_fuel <= 0 && On)
        {
            DisableFire();
        }

    }
    public void ActivateFire()
    {
      On = true;
      _smoke.Play();
    }
    private void DisableFire()
    {
        _smoke.Stop();
        On = false;
    }

    public void Interact(GameObject interactingObject)
    {
        if (_fuel < _maxFuel)
        {
            var interactingInv = interactingObject.GetComponentInChildren<Inventory>();
            if (_itemTaker.TakeItems(interactingInv))
            {

                AddFuel(_fuelAddAmount);
                if (!On)
                {
                    ActivateFire();
                }
            }
        }
    }
    public void AddFuel(float fuelAmount)
    {
        _fuel += fuelAmount;
        _campfireParticleController.SetParticleSizeFromFloat(_fuel);
    }
    private void UpdateLightRadius()
    {
        _flameLightController.SetLightRadius(_fuel / _maxFuel);
    }
}
