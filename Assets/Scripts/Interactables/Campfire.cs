using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Campfire : MonoBehaviour, IInteractable, IHeatSource
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
    public List<HeatingSystem> heatingSystems;
    public int MaxHeatValue;

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

        if(heatingSystems.Count > 0)
        {
            ApplyHeat();
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

    public int GetHeatValue()
    {
        Debug.Log("Getting Value");
        return (int)(MaxHeatValue * (_fuel / _maxFuel));
    }
    public void ApplyHeat()
    {
        var heatValue = GetHeatValue();

        foreach (var item in heatingSystems)
        {
            item.ApplyHeat(heatValue);
        }
    }
    public bool IsActive()
    {
        return On;
    }
    private void OnTriggerEnter(Collider other)
    {
        var systems = other.gameObject.GetComponentsInChildren<HeatingSystem>();
        if(systems != null)
        {
            foreach (var item in systems)
            {
                if (!heatingSystems.Contains(item))
                {
                    heatingSystems.Add(item);
                }
            }
            Debug.Log("Object has Heating System");
        }
    }
    private void OnTriggerExit(Collider other)
    {
      if (other.gameObject.GetComponents<HeatingSystem>() != null)
        {
            var exitingObjects = other.gameObject.GetComponentsInChildren<HeatingSystem>();

            foreach (var item in exitingObjects)
            {
                heatingSystems.Remove(item);
            }

            Debug.Log("Object has Heating System");
        }
    }
}
 