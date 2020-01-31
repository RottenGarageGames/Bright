using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public float PlaceRangex;
    public float PlaceRangey;
    public float PlaceRangez;

    public GameObject ObjectToPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetObjectToPlace(GameObject objectToPlace)
    {
        ObjectToPlace = objectToPlace;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPlace)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
                Debug.DrawLine(ray.origin, hit.point);
        }
    }
}
