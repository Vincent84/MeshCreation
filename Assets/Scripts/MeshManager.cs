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

        StartCoroutine(MeshCreator());

    }

    private void Update()
    {


        
            //mesh.triangles = newTriangles;
        
    }

    IEnumerator MeshCreator()
    {
        
        mesh.Clear();

        int randomY1 = Random.Range(1, 51);
        int randomX1 = Random.Range(1, 51);

        int randomY2 = Random.Range(1, 51);
        int randomX2 = Random.Range(1, 51);

        //int randomVertice = 9;
        newVertices = new Vector3[] { new Vector3(0, 0, 0),
                                          new Vector3(0, randomY1, 0),
                                          new Vector3(randomX1, randomY1, 0),
                                          new Vector3(0, 0, 0),
                                          new Vector3(0, -(Mathf.Abs(randomY2)), 0),
                                          new Vector3(-(Mathf.Abs(randomX2)), -(Mathf.Abs(randomY2)), 0)
            };
        newUV = new Vector2[] { new Vector2(0, 0),
                                    new Vector2(0,  randomY1),
                                    new Vector2(randomX1, randomY1),
                                    new Vector2(0, 0),
                                    new Vector2(0,  -(Mathf.Abs(randomY2))),
                                    new Vector2(-(Mathf.Abs(randomX2)), -(Mathf.Abs(randomY2)))
            };

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;

        GetComponent<MeshRenderer>().material.color = Color.black;

        yield return new WaitForSeconds(2f);

        StartCoroutine(MeshCreator());
    }

}
