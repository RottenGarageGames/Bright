using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public MeshFilter MeshFilter;
    public Material Material;
    public Mesh mesh;
    public int xSize = 20;
    public int zSize = 20;
    public Vector3[] vertices;
    int[] triangles;

    public List<Vector3> SouthVertices;
    public List<Vector3> NorthVertices;
    public List<Vector3> EastVertices;
    public List<Vector3> WestVertices;

    public float perlinYVar = .1f;
    public float perlinXVar = .1f;

    public Vector2 WorldLocation;

    private void InitializeGenerator()
    {
        MeshFilter = gameObject.GetComponent<MeshFilter>();
        mesh = new Mesh();
        gameObject.GetComponent<MeshRenderer>().material = Material;

        SouthVertices = new List<Vector3>();
        NorthVertices = new List<Vector3>();
        EastVertices = new List<Vector3>();
        WestVertices = new List<Vector3>();
    }
    public void Generate()
    {
        InitializeGenerator();
        SetVertices();
        UpdateMesh();
    }
    public void Generate(List<Vector3> southVertices = null, List<Vector3> eastVertices = null, List<Vector3> westVertices = null, List<Vector3> northVertices = null)
    {
        InitializeGenerator();
        SetVertices(southVertices, eastVertices,westVertices,northVertices);
        UpdateMesh();
    }
    public void SetVertices(List<Vector3> neighborNorthVertices = null, List<Vector3> neighborWestVertices = null, List<Vector3> neighborEastVertices = null, List<Vector3> neighborSouthVertices = null)
    {
        bool neighborEastVerticesExist = neighborEastVertices?.Count > 0;
        bool neighborSouthVerticesExist = neighborSouthVertices?.Count > 0;
        bool neighborNorthVerticesExist = neighborNorthVertices?.Count > 0;
        bool neighborWestVerticesExist = neighborWestVertices?.Count > 0;

        float localX = 0f;
        float localZ = 0f;

        if(neighborNorthVertices != null)
        {
            localX = neighborNorthVertices.Min(x => x.x);
        }

        if(neighborWestVertices != null)
        {
            localX = neighborWestVertices.Max(vertex => vertex.x);
            localZ= neighborWestVertices.Min(vertex => vertex.z);
        }
      


        float y = 0;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int z = 0, i = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
 
             y = Mathf.PerlinNoise(x * perlinXVar, z * perlinYVar) * 2f;

                var currentPoint = new Vector3(x + localX, y, z + localZ);
                //vertices[i] = currentPoint;
                //if(x == 0 && z == 0)
                //{
                //    bool westVertexAdded = false;
                //    bool southVertexAdded = false;

                //    if(neighborEastVerticesExist || neighborNorthVerticesExist)
                //    {
                //        if (neighborEastVerticesExist)
                //        {
                //            var neighborVertex = neighborEastVertices.ElementAt(x);
                //            vertices[i] = neighborVertex;
                //            WestVertices.Add(neighborVertex);
                //            westVertexAdded = true;
                //        }
                //        if(neighborNorthVerticesExist)
                //        {
                //            if(!westVertexAdded)
                //            {
                //                var neighborVertex = neighborNorthVertices.ElementAt(x);
                //                vertices[i] = neighborVertex;
                //                SouthVertices.Add(neighborVertex);
                //                southVertexAdded = true;
                //            }
                //        }
                //    }
                //}
                if (x == 0)
                {
                    if (neighborEastVertices?.Count > 0)
                    {
                        var neighborVertex = neighborEastVertices.ElementAt(x);
                        vertices[i] = neighborVertex;
                        WestVertices.Add(neighborVertex);

                        if (z == 0)
                        {
                            SouthVertices.Add(neighborVertex);
                        }
                        if (z == zSize)
                        {
                            NorthVertices.Add(neighborVertex);
                        }
                    }
                    else
                    {
                        WestVertices.Add(currentPoint);
                        vertices[i] = currentPoint;

                        if(z == 0)
                        {
                            SouthVertices.Add(currentPoint);
                        }
                        if (z == zSize)
                        {
                            NorthVertices.Add(currentPoint);
                        }
                    }


                }
                else if(z == 0)
                {
                    if(neighborNorthVertices?.Count > 0)
                    {
                        var neighborVertex = neighborNorthVertices.ElementAt(x);
                        vertices[i] = neighborVertex;
                        SouthVertices.Add(neighborVertex);

                        if (x == xSize)
                        {
                            EastVertices.Add(neighborVertex);
                        }
                    }
                    else
                    {
                        SouthVertices.Add(currentPoint);
                        vertices[i] = currentPoint;
                        if (x == xSize)
                        {
                            EastVertices.Add(currentPoint);
                        }
                    }
                }
                else if(x == xSize)
                {
                    if(neighborWestVertices?.Count > 0)
                    {
                        var neighborVertex = neighborWestVertices.ElementAt(x);
                        vertices[i] = neighborVertex;
                        EastVertices.Add(neighborVertex);

                        if(z == zSize)
                        {
                            NorthVertices.Add(neighborVertex);
                        }
                    }
                    else
                    {
                        EastVertices.Add(currentPoint);
                        vertices[i] = currentPoint;
                        if (z == zSize)
                        {
                            NorthVertices.Add(currentPoint);
                        }
                    }
                }
                else if(z == zSize)
                {
                    if(neighborSouthVertices?.Count > 0)
                    {
                        var neighborVertex = neighborSouthVertices.ElementAt(x);
                        vertices[i] = neighborVertex;
                        NorthVertices.Add(neighborVertex);
                    }
                    else
                    {
                        NorthVertices.Add(currentPoint);
                        vertices[i] = currentPoint;
                    }
                }
                else
                {
                    vertices[i] = currentPoint;
                }

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }

            vert++;
        }
    }
    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        MeshFilter.mesh = mesh;
    }
}
