using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadCreator : MonoBehaviour
{
    private float multiplier = 1;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            multiplier += 1;
        }
        MakeQuad(multiplier);
    }
    private void MakeQuad(float a)
    {
        var mf = GetComponent<MeshFilter>();

        var mesh = new Mesh();
        mf.mesh = mesh;

        var vertices = new Vector3[4]
        {
            new Vector3(a,0,a),
            new Vector3(a,0,-a),
            new Vector3(-a,0,-a),
            new Vector3(-a,0,a)
        };
        mesh.vertices = vertices;

        var tris = new int[6] { 0, 1, 2, 2, 3, 0 };
        mesh.triangles = tris;
        mesh.RecalculateNormals();
    }
}
