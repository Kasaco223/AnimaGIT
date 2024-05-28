using UnityEngine;

public class Entrada : MonoBehaviour
{
    public bool corriente = true;

    private void OnTriggerEnter(Collider other)
    {
        // Obt�n el componente ObjetoContagiable del objeto colisionado
        ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
        if (receptor != null)
        {
            // Env�a directamente el valor booleano
            receptor.RecibirConexion(corriente);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
        if (receptor != null)
        {
            receptor.RecibirDesconexion();
        }
    }
}