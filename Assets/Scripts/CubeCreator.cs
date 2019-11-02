using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
     float Xpos1, Xpos2;

    private void Awake()
    {
        Xpos2 = 1;
        MakeMesh(Xpos1,Xpos2);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Xpos1 += 1;
            Xpos2 += 1;
        }
        MakeMesh(Xpos1, Xpos2);
    }
    private void MakeMesh(float Xpos1, float Xpos2)
    {
        var mf = GetComponent<MeshFilter>();

        var mesh = new Mesh();
        mf.mesh = mesh;

        var vertices = new Vector3[8]
{
            new Vector3(Xpos1,3,0),
            new Vector3(Xpos2,3,0),
            new Vector3(Xpos1,3,1),
            new Vector3(Xpos2,3,1),
            new Vector3(Xpos1,4,0),
            new Vector3(Xpos2,4,0),
            new Vector3(Xpos1,4,1),
            new Vector3(Xpos2,4,1)
};
        mesh.vertices = vertices;

        var tris = new int[36]
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
}
