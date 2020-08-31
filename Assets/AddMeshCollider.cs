using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMeshCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cavePieces = gameObject.GetComponentsInChildren<Transform>();

        foreach (var item in cavePieces)
        {
            item.gameObject.AddComponent<MeshCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
