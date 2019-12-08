using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public float endYPos;
    public float step;

    private void Update()
    {
        if(transform.position.y >= endYPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
        }
    }
}
