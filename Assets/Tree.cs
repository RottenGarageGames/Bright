using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    public GameObject LogPrefab;
    public void Interact()
    {
        Instantiate(LogPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
