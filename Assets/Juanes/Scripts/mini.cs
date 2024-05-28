using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoMovimiento : MonoBehaviour
{

    [SerializeField] private Material skybox;
    private float elapsedtime = 0;
    private float timescale = 2.5f;
    private static readonly int Rotation = Shader.PropertyToID("_Rotation");

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;
        skybox.SetFloat(Rotation, elapsedtime * timescale);
    }
}
