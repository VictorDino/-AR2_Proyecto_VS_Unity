using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGod : MonoBehaviour
{
    public OpenDoor door;
    private int totalCubes;

    void Start()
    {
        Cube[] cubes = FindObjectsOfType<Cube>();
        totalCubes = cubes.Length;
        foreach (Cube cube in cubes)
        {
            cube.SetSceneManager(this);
        }
    }

    public void CubeDestroyed()
    {
        totalCubes--;
        if (totalCubes <= 0)
        {
            door.Open();
        }
    }
}
