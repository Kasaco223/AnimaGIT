using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    private ControladorJuego controladorJuego;
    public float velocidad = 2.0f;
    public float posicionUmbral = 330.0f;

    void Start()
    {
        controladorJuego = FindObjectOfType<ControladorJuego>();
        if (controladorJuego == null)
        {
            Debug.LogError("No se encontró el ControladorJuego en la escena.");
        }
    }

    void Update()
    {
       
        transform.Translate(Vector3.right * controladorJuego.VelocidadActual * Time.deltaTime);

        if (transform.position.x >= posicionUmbral)
        {
            // Llamar al método y mostrar un mensaje de depuración
            MetodoEspecial();
            Debug.Log("Se ha llamado al método");
        } 
        if (Input.GetKeyDown(KeyCode.S))
        {
            controladorJuego.AumentarVelocidadYMultiplicador();
        }
        void MetodoEspecial()
        {

        }
    }
}