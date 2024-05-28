using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Asegura que el objeto tenga un Rigidbody adjunto
public class FollowBackground : MonoBehaviour
{
    public GameObject jugador; // Referencia al objeto del jugador
    private Rigidbody rb; // Referencia al Rigidbody del objeto que contiene este script

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        rb.isKinematic = true; // Hacer el Rigidbody kinemático para que no sea afectado por la física
    }

    void Update()
    {
        if (jugador != null) // Asegurarse de que el objeto del jugador esté asignado
        {
            Vector3 nuevaPosicion = transform.position; // Obtener la posición actual del objeto que contiene este script
            nuevaPosicion.x = jugador.transform.position.x + 2f; // Copiar la posición en X del objeto del jugador y agregar un desplazamiento de 2 unidades
            rb.MovePosition(nuevaPosicion); // Mover el objeto a la nueva posición de manera suave
        }
    }
}
