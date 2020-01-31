using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRB;

    public float speed = 15;
    public float RotationSpeed = 20;
    public float JumpForce = 5;

    public float InteractTimer;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Forward") != 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

            if (Input.GetAxis("Forward") < 0)
            {
                if (speed > 0)
                {
                    speed *= -1;
                }
            }
            else if (Input.GetAxis("Forward") > 0)
            {
                if (speed < 0)
                {
                    speed *= -1;
                }
            }

            if (Input.GetAxis("Jump") > 0)
            {
                myRB.velocity = transform.up * JumpForce;
            }
            if (Input.GetAxis("Interact") > 0 && Timer > InteractTimer)
            {
                Debug.Log("Interact Called");
                ScanForInteractables();
                Timer = 0f;
            }
            if (Input.GetAxis("Attack") > 0)
            {

            }
    }
    private void ScanForInteractables()
    {

        // Want to change this to use a ray cast instead.
        var container = gameObject.GetComponent<InteractableColliderContainer>();
        var items = container.GetInteractableItems();

        foreach (var item in items)
        {
            var interactable = item.gameObject.GetComponent<IInteractable>();
            interactable.Interact(gameObject);
        }

    }

}
