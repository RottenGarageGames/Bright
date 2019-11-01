using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    private SphereCollider _enterTrigger;
    public float RotationRate;
    public float TimeBetweenRotations;
    public float MaxRotation;
    public float Timer;
    public bool InRange;
    // Start is called before the first frame update
    void Start()
    {
        _enterTrigger = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange && (gameObject.transform.rotation.y < MaxRotation))
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeBetweenRotations)
            {
                gameObject.transform.Rotate(new Vector3(0, RotationRate));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        InRange = false;
    }
}
