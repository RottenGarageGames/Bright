using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canoe : MonoBehaviour, IInteractable
{
    public Transform Seat;

    public bool UsingVehicles;

    public float Speed;
    public GameObject Player;

    public void Interact(GameObject interactingObject)
    {
        if (!UsingVehicles)
        {
            interactingObject.transform.position = Seat.position;
            UsingVehicles = true;
            Player = interactingObject;

        }
        else
        {
            UsingVehicles = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (UsingVehicles)
        {
            Player.transform.position = gameObject.transform.position;
            if (Input.GetAxis("Forward") != 0)
            {
                transform.Translate(0, 0, Speed * Time.deltaTime, Space.Self);
            }
        }
    }
}
