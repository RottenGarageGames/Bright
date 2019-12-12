using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public int ChunkSize;
    public List<MeshGenerator> landMeshes;
    public Vector3 ChunkWorldPos;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Chunk";
        landMeshes = new List<MeshGenerator>();


            var landChunk = new GameObject();
            landChunk.AddComponent<MeshFilter>();
            landChunk.AddComponent<MeshRenderer>();
            var land = landChunk.AddComponent<MeshGenerator>();
            land.Generate();
            landChunk.transform.parent = gameObject.transform;

            land.WorldLocation = new Vector3(0, 0, 0);
            landMeshes.Add(land);

        var landChunk2 = new GameObject();
        landChunk2.AddComponent<MeshFilter>();
        landChunk2.AddComponent<MeshRenderer>();
        var land2 = landChunk2.AddComponent<MeshGenerator>();
        land2.Generate(null,land.EastVertices,null,null);
        landChunk2.transform.parent = gameObject.transform;

        land2.WorldLocation = new Vector3(1, 0, 0);
        landMeshes.Add(land2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
