using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CampfireParticleController : ParticleController
{
    // Start is called before the first frame update

    public string FlameParticleSystemName;

    void Start()
    {
        SetParticleSystems();
    }
    public override void SetParticleSystems()
    {
        ParticleSystems = new List<ParticleSystem>(gameObject.GetComponentsInChildren<ParticleSystem>().Where(x => x.name == FlameParticleSystemName));
    }


}
