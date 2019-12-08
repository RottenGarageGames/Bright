using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    public GameObject LogPrefab;
    public int SpawnCount;
    public void Interact(GameObject interactor)
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Instantiate(LogPrefab, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
