using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaler : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public float MinZ;
    public float MaxZ;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(Random.Range(MinX, MinY),Random.Range(MinY,MaxY),Random.Range(MinZ,MaxZ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
