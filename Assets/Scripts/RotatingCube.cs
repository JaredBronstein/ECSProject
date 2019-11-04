using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    Quaternion Rotation = new Quaternion();
    Vector3[] vertices;
    int[] tris;

    [SerializeField]
    private int X, Y, Z;

    void Update()
    {
        MakeMesh();
        Rotate();
    }

    private void Rotate()
    {
        //Quaternion Rotation = Quaternion.Euler(X,Y,Z);
        //Rotation.eulerAngles = new Vector3(X,Y,Z);
        //Vector3 center = new Vector3(0, 0, 0);
        //for (int i = 0; i < vertices.Length; i++)
        //{
        //    vertices[i] = Rotation * (vertices[i] - center) + center;
        //}
        transform.Rotate(X, Y, Z);
    }

    void MakeMesh()
    {
        var mf = GetComponent<MeshFilter>();
 
        var mesh = new Mesh();
        mf.mesh = mesh;

        vertices = new Vector3[8]
{
            new Vector3(-1,-1,-1),
            new Vector3(1,-1,-1),
            new Vector3(-1,-1,1),
            new Vector3(1,-1,1),
            new Vector3(-1,1,-1),
            new Vector3(1,1,-1),
            new Vector3(-1,1,1),
            new Vector3(1,1,1)
};
        mesh.vertices = vertices;

        tris = new int[36]
        {
            1,2,0,
            1,3,2,
            0,4,1,
            4,5,1,
            1,5,3,
            5,7,3,
            4,0,2,
            2,6,4,
            2,3,7,
            7,6,2,
            4,6,5,
            6,7,5
        };
        mesh.triangles = tris;
        mesh.RecalculateNormals();

    }
    void RotateY(Mesh mesh)
    {
        Vector3 center = (mesh.vertices[0] + mesh.vertices[7])/2;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {

        }
    }
}
