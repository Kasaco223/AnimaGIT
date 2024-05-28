using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour

{
    public float speed;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    /*void LateUpdate()
    {
        if (transform.position.x < initialPosition.x - 10f) 
        {
            transform.position = initialPosition;
        }
    } */
}
