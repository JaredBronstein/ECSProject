using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CubePrefab;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SpawnCube();
        }
    }
    void SpawnCube()
    {
        GameObject CubeClone = Instantiate(CubePrefab);
        CubeClone.GetComponent<RotatingCube>().SpeedX = Random.Range(-0.1f, 0.1f);
        CubeClone.GetComponent<RotatingCube>().SpeedZ = Random.Range(-0.1f, 0.1f);
        CubeClone.GetComponent<RotatingCube>().TurnSpeedX = Random.Range(-0.5f, 0.5f);
        CubeClone.GetComponent<RotatingCube>().TurnSpeedY = Random.Range(-0.5f, 0.5f);
        CubeClone.GetComponent<RotatingCube>().TurnSpeedZ = Random.Range(-0.5f, 0.5f);
    }
}
