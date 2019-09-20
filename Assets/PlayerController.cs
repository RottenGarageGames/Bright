using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRB;

    public float speed = 15;
    public float RotationSpeed = 20;
    public float JumpForce = 5;

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

        if(Input.GetAxis("Jump") > 0)
        {
            myRB.velocity = transform.up * JumpForce;
        }


    }
}
