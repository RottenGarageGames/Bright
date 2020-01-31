using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public float Y;
    public float X;
    public float Z;

    public Material Material;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < X; i++)
        {
            for(int k = 0; k < Y; k++)
            {
                for (int j = 0; j < Z; j++)
                {

                    var cube = new GameObject();
                    cube.AddComponent<MeshFilter>();
                  var cubeGenerator = cube.AddComponent<CubeGenerator>();
                    cubeGenerator.Material = Material;
                    
                    cube.transform.position = new Vector3(i, k, j);
                    cube.transform.parent = this.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
