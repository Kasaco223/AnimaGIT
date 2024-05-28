using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectsChangePosition : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] points;

    void Start()
    {
        maxX = points.Max(point => point.position.x);
        minX = points.Min(point => point.position.x);
        maxY = points.Max(point => point.position.y);
        minY = points.Min(point => point.position.y);
       
        ChangePosition();
    }

    private void ChangePosition()
    {
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
