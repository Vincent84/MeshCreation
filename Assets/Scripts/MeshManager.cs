using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour {

    public Vector3[] newVertices;
    public Vector2[] newUV;
    public int[] newTriangles;
    private Mesh mesh;

    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        // make changes to the Mesh by creating arrays which contain the new values
        //newVertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
        //newUV = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //newTriangles = new int[] { 0, 1, 2 };

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        meshRenderer.material.color = Color.black;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            mesh.Clear();

            int randomVertice = Random.Range(-30, 30);
            //int randomVertice = 9;
            newVertices = new Vector3[] { new Vector3(0, 0, 0),
                                          new Vector3(0, randomVertice, 0),
                                          new Vector3(randomVertice, randomVertice, 0),
                                          new Vector3(0, 0, 0),
                                          new Vector3(0, randomVertice, 0),
                                          new Vector3(randomVertice, randomVertice, 0)
            };
            newUV = new Vector2[] { new Vector2(0, 0),
                                    new Vector2(0, randomVertice),
                                    new Vector2(randomVertice, randomVertice),
                                    new Vector2(0, 0),
                                    new Vector2(0, randomVertice),
                                    new Vector2(randomVertice, randomVertice)
            };
            mesh.vertices = newVertices;
            mesh.uv = newUV;
            mesh.triangles = newTriangles;

            GetComponent<MeshRenderer>().material.color = Color.black;

            //mesh.triangles = newTriangles;
        }
    }

}
