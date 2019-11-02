using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGrid : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    [SerializeField]
    private float cellSize = 1;
    [SerializeField]
    private Vector3 gridOffset;
    [SerializeField]
    private int gridSize;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        InvokeRepeating("Expand", 2.0f, 1.0f);
    }
    private void Expand()
    {
        cellSize++;
        gridSize++;
    }
    private void Update()
    {        
        MakeContiguousProceduralGrid();
        UpdateMesh();
    }
    private void MakeDiscreteProceduralGrid()
    {
        vertices = new Vector3[(gridSize+1) * (gridSize+1)];
        triangles = new int[gridSize * gridSize * 6];

        int v = 0, t = 0;
        float vertexOffset = cellSize * 0.5f;

        for(int x = 0; x <= gridSize; x++)
        {
            for(int y = 0; y <= gridSize; y++)
            {
                vertices[v] = new Vector3((x*cellSize) - vertexOffset,(x+y) * 0.2f,(y*cellSize) - vertexOffset);
                v++;
            }
        }

        v = 0;

        for(int x = 0; x < gridSize; x++)
        {
            for(int y = 0; y <gridSize; y++)
            {
                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v+1;
                triangles[t + 2] = triangles[t + 3] = v+(gridSize+1);
                triangles[t + 5] = v + (gridSize + 1) + 1;
                v++;
                t += 6;
            }
            v++;
        }
    }
    private void MakeContiguousProceduralGrid()
    {
        vertices = new Vector3[gridSize * gridSize * 4];
        triangles = new int[gridSize * gridSize * 6];

        int v = 0, t = 0;
        float vertexOffset = cellSize * 0.5f;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellSize, 0, y * cellSize);

                vertices[v] = new Vector3(-vertexOffset, x + y, -vertexOffset) + cellOffset + gridOffset;
                vertices[v + 1] = new Vector3(-vertexOffset, x + y, vertexOffset) + cellOffset + gridOffset;
                vertices[v + 2] = new Vector3(vertexOffset, x + y, -vertexOffset) + cellOffset + gridOffset;
                vertices[v + 3] = new Vector3(vertexOffset, x + y, vertexOffset) + cellOffset + gridOffset;

                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + 2;
                triangles[t + 5] = v + 3;

                v += 4;
                t += 6;
            }
        }
    }
    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
