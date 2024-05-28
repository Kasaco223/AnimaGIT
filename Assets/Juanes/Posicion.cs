using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontColliderDebugger : MonoBehaviour
{
    private void Update()
    {
        Vector3 colliderPosition = transform.position;

        Debug.Log("Front Collider Position: " + colliderPosition);
    }
}