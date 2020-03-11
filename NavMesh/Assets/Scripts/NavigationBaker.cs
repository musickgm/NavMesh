using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Bake NavMeshes at runtime
/// </summary>
public class NavigationBaker : MonoBehaviour
{
    public NavMeshSurface[] surfaces;       //NavMeshes to bake
    public Transform[] objectsToRotate;     //Surfaces to rotate

    // Start is called before the first frame update
    void Start()
    {
        //Rotate transforms
        for (int j = 0; j < objectsToRotate.Length; j ++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }
        //Bake NavMeshes
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }


}
