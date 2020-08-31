using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetect : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Target;
    public bool InRange;
    public NavMeshAgent agent;
    public float RotationSmoothing;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange)
        {
            agent.destination = Target.position;
            RotateTowardsTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Target = other.transform;
            InRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Target = null;
            InRange = false;
        }
    }
    private void RotateTowardsTarget()
    {
        Vector3 targetDirection = Target.transform.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, RotationSmoothing, 0f);

        Debug.DrawRay(transform.position, newDirection, Color.green, 5f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
