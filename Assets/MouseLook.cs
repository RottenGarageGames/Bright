using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float MouseXSensitivity;
    [SerializeField] float MouseYSensitivity;
    private Camera _camera;

    private float yaw = 0f;
    private float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
       _camera = gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        yaw  += MouseXSensitivity * Input.GetAxis("Mouse X");
        pitch -= MouseYSensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, gameObject.GetComponentInParent<Transform>().position.x, 0f);

    }
}
