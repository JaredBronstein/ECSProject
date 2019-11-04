using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniFaceCreator : MonoBehaviour
{
    [SerializeField]
    private int SideFaces = 3;
    [SerializeField]
    private int Height = 2;
    [SerializeField]
    private double Radius = 0.5f;

    private void Update()
    {
        MakeMesh(SideFaces, Height, Radius);
    }
    private void MakeMesh(int faces, int height, double radius)
    {
        Vector3 midpointB = new Vector3(0, 0, 0);
        Vector3 midpointT = new Vector3(0, height, 0);
    }
}
