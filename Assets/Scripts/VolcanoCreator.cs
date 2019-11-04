using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoCreator : MonoBehaviour
{
    [SerializeField]
    private int BottomLength, BottomWidth, TopLength, TopWidth, Height;
    // Start is called before the first frame update
    void Awake()
    {
        //BottomLength = 7;
        //BottomWidth = 5;
        //TopLength = 2;
        //TopWidth = 1;
        //Height = 6;
    }

    // Update is called once per frame
    void Update()
    {
        MakeMesh(BottomLength, BottomWidth, TopLength, TopWidth, Height);
    }
    private void MakeMesh(int bottomLength, int bottomWidth, int topLength, int topWidth, int height)
    {
        var mf = GetComponent<MeshFilter>();

        var mesh = new Mesh();
        mf.mesh = mesh;

        var vertices = new Vector3[18]
        {
            new Vector3(0,0,0),
            new Vector3(bottomWidth,0,bottomLength),
            new Vector3(bottomLength,0,bottomWidth),
            new Vector3(bottomLength,0,-bottomWidth),
            new Vector3(bottomWidth,0,-bottomLength),
            new Vector3(-bottomWidth,0,-bottomLength),
            new Vector3(-bottomLength,0,-bottomWidth),
            new Vector3(-bottomLength,0,bottomWidth),
            new Vector3(-bottomWidth,0,bottomLength),
            new Vector3(topWidth,height,topLength),
            new Vector3(topLength,height,topWidth),
            new Vector3(topLength,height,-topWidth),
            new Vector3(topWidth,height,-topLength),
            new Vector3(-topWidth,height,-topLength),
            new Vector3(-topLength,height,-topWidth),
            new Vector3(-topLength,height,topWidth),
            new Vector3(-topWidth,height,topLength),
            new Vector3(0,height-1,0)
        };
        mesh.vertices = vertices;

        var tris = new int[96]
        {
            0,2,1,
            0,3,2,
            0,4,3,
            0,5,4,
            0,6,5,
            0,7,6,
            0,8,7,
            0,1,8,
            17,9,10,
            17,10,11,
            17,11,12,
            17,12,13,
            17,13,14,
            17,14,15,
            17,15,16,
            17,16,9,
            1,2,9,
            10,9,2,
            2,3,10,
            11,10,3,
            3,4,11,
            12,11,4,
            4,5,12,
            13,12,5,
            5,6,13,
            14,13,6,
            6,7,14,
            15,14,7,
            7,8,15,
            16,15,8,
            8,1,16,
            9,16,1
        };
        mesh.triangles = tris;
        mesh.RecalculateNormals();
    }
}
