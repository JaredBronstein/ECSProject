using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    Vector3[] vertices;
    int[] tris;
    float temp1, temp2;
    float[] Xpos = new float[8], Ypos = new float[8], Zpos = new float[8];
    private ParticleSystem ps;

    public double TurnSpeedX, TurnSpeedY, TurnSpeedZ;

    [SerializeField]
    Vector3 Center = new Vector3(0, 7, 0);

    public float SpeedX, SpeedY, SpeedZ, Acceleration;

    private void Awake()
    {
        ps = this.GetComponentInChildren<ParticleSystem>();
        Xpos[0] = Xpos[2] = Xpos[4] = Xpos[6] = -1;
        Xpos[1] = Xpos[3] = Xpos[5] = Xpos[7] = 1;
        Ypos[0] = Ypos[1] = Ypos[2] = Ypos[3] = -1;
        Ypos[4] = Ypos[5] = Ypos[6] = Ypos[7] = 1;
        Zpos[0] = Zpos[1] = Zpos[4] = Zpos[5] = -1;
        Zpos[2] = Zpos[3] = Zpos[6] = Zpos[7] = 1;
        Invoke("Delete", 2.0f);
    }

    void Update()
    {
        ps.transform.position = Center;
        Rotate();
        MakeMesh(Center);
        MoveCenter();
    }

    void MakeMesh(Vector3 center)
    {
        var mf = GetComponent<MeshFilter>();

        var mesh = new Mesh();
        mf.mesh = mesh;

        vertices = new Vector3[8]
{
            new Vector3(center.x+Xpos[0],center.y+Ypos[0],center.z+Zpos[0]),
            new Vector3(center.x+Xpos[1],center.y+Ypos[1],center.z+Zpos[1]),
            new Vector3(center.x+Xpos[2],center.y+Ypos[2],center.z+Zpos[2]),
            new Vector3(center.x+Xpos[3],center.y+Ypos[3],center.z+Zpos[3]),
            new Vector3(center.x+Xpos[4],center.y+Ypos[4],center.z+Zpos[4]),
            new Vector3(center.x+Xpos[5],center.y+Ypos[5],center.z+Zpos[5]),
            new Vector3(center.x+Xpos[6],center.y+Ypos[6],center.z+Zpos[6]),
            new Vector3(center.x+Xpos[7],center.y+Ypos[7],center.z+Zpos[7])
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
    void Rotate()
    {
        RotateX(TurnSpeedX);
        RotateY(TurnSpeedY);
        RotateZ(TurnSpeedZ);
    }
    void RotateX(double turnSpeed)
    {
        for (int i = 0; i < Ypos.Length; i++)
        {
            temp1 = Ypos[i];
            temp2 = Zpos[i];
            Ypos[i] = Convert.ToSingle((temp1) * Math.Cos(turnSpeed) + (temp2) * Math.Sin(turnSpeed));
            Zpos[i] = Convert.ToSingle((temp2) * Math.Cos(turnSpeed) - (temp1) * Math.Sin(turnSpeed));
        }
    }
    void RotateY(double turnSpeed)
    {
        for (int i = 0; i < Xpos.Length; i++)
        {
            temp1 = Xpos[i];
            temp2 = Zpos[i];
            Xpos[i] = Convert.ToSingle((temp1) * Math.Cos(turnSpeed) + (temp2) * Math.Sin(turnSpeed));
            Zpos[i] = Convert.ToSingle((temp2) * Math.Cos(turnSpeed) - (temp1) * Math.Sin(turnSpeed));
        }
    }
    void RotateZ(double turnSpeed)
    {
        for (int i = 0; i < Xpos.Length; i++)
        {
            temp1 = Xpos[i];
            temp2 = Ypos[i];
            Xpos[i] = Convert.ToSingle((temp1) * Math.Cos(turnSpeed) + (temp2) * Math.Sin(turnSpeed));
            Ypos[i] = Convert.ToSingle((temp2) * Math.Cos(turnSpeed) - (temp1) * Math.Sin(turnSpeed));
        }
    }
    void MoveCenter()
    {
        Center.x += SpeedX;
        Center.y += SpeedY;
        Center.z += SpeedZ;
        SpeedY -= Acceleration;
    }
    void Delete()
    {
        Destroy(this.gameObject);
    }
}
