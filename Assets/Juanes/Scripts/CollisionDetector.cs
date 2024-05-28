using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private List<GameObject> objetosColisionados = new List<GameObject>();
    private double puntos = 0;
    private ControladorJuego controladorJuego;
    private double puntosextra = 0.5;
    private UIManager uiManager;


    void Start()
    {

        controladorJuego = FindObjectOfType<ControladorJuego>();
        uiManager = FindObjectOfType<UIManager>();

        if (controladorJuego == null)
        {
            Debug.LogError("No se encontró el ControladorJuego en el mismo GameObject.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W))
        {
            VerificarTecla();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActivarMultiplicador();
        }
        uiManager.ActualizarPuntos(puntos);
    }
    private void VerificarTecla()
    {
        bool teclaCorrecta = false;

        foreach (var objeto in objetosColisionados)
        {
            PrefabKey prefabKey = objeto.GetComponent<PrefabKey>();

            if (prefabKey != null && Input.GetKeyDown(prefabKey.TeclaEsperada))
            {
                teclaCorrecta = true;
                break;
            }
        }

        if (teclaCorrecta)
        {
            puntos += 1;
            if (controladorJuego.MultiplicadorActivado)
            {
                puntos = puntos += puntosextra;
                Debug.Log("¡Punto multiplicado! Puntos totales: " + puntos);
            }
            else
            {
                Debug.Log("Punto! Puntos totales: " + puntos);
            }
        
        }
        else
        {
            Debug.Log("Botón incorrecto");
        }

        objetosColisionados.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objetovalido") && !objetosColisionados.Contains(other.gameObject))
        {
            objetosColisionados.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("objetovalido"))
        {
            objetosColisionados.Remove(other.gameObject);
        }
    }
    private void AumentarVelocidadYPuntos()
    {
        controladorJuego.AumentarVelocidadYMultiplicador();
    }
    private void ActivarMultiplicador()
    {
        controladorJuego.SetMultiplicadorActivado();
    }
}