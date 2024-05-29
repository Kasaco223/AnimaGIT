using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveBackground : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
       
        transform.Translate(Vector3.left * speed * Time.deltaTime);

       
        if (transform.position.x < -20f) 
        {
            transform.position = new Vector3(20f, transform.position.y, transform.position.z); 
        }
    }
}