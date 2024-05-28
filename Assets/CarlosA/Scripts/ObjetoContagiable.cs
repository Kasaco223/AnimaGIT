using UnityEngine;

public class ObjetoContagiable : MonoBehaviour
{
    public bool corriente = false; // Cambiado de público a privado
    private bool validar = false;
    void Update()
    {
       // Validacion();
    }

    // Método para recibir la señal de conexión
    public void RecibirConexion(bool estado)
    {
        corriente = estado;
    }

    // Método para recibir la señal de desconexión
    public void RecibirDesconexion()
    {
        corriente = false;
    }
    private void OnTriggerExit(Collider other)
    {
        /*
        if (!corriente) {
            ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
            if (receptor != null)
            {
                receptor.RecibirDesconexion();
                Debug.Log("Desconectado");
            }
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (corriente)
        {
            validar = true;
           // if (validar)
           // {
                ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
                if (receptor != null)
                {
                    // Envía directamente el valor booleano
                    receptor.RecibirConexion(corriente);
                    //validar = true;
                }

           // }

            Salida2 receptor2 = other.GetComponent<Salida2>();
            if (receptor2 != null)
            {
                // Envía directamente el valor booleano
                receptor2.RecibirConexion(corriente);
            }
        }

        
        }
    /*
    else
    {
        ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
        if (receptor != null)
        {
            receptor.RecibirDesconexion();
            Debug.Log("Desconectado");
        }
    }
    */
    /*
    private void Validacion(Collider other)
    {
        if (validar)
        {
            ObjetoContagiable receptor = other.GetComponent<ObjetoContagiable>();
            if (receptor != null)
            {
                // Envía directamente el valor booleano
                receptor.RecibirConexion(corriente);
                validar = true;
            }

        }
    }
    */

} 

    
   
