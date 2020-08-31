using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Interact") > 0)
        {
            Debug.Log("Interact Called");
            ScanForInteractables();
        }
    }

    private void ScanForInteractables()
    {
        var container = gameObject.GetComponentInChildren<Camera>().GetComponent<InteractableColliderContainer>();
        var items = container.GetInteractableItems();

        foreach (var item in items)
        {
            var interactable = item.gameObject.GetComponent<IInteractable>();
            interactable.Interact(gameObject);
        }

    }
}
