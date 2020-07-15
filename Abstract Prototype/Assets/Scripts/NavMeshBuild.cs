using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuild : MonoBehaviour
{
    public NavMeshSurface surface;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
            surface.BuildNavMesh();
    }
}
