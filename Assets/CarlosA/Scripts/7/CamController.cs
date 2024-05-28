using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform objeto; // El objeto que la c�mara seguir�
    private float altura; // La altura inicial de la c�mara

    void Start()
    {
        // Guardar la altura inicial de la c�mara
        altura = transform.position.y;
    }

    void Update()
    {
        // Crear una nueva posici�n para la c�mara que copia la posici�n x del objeto
        Vector3 nuevaPosicion = new Vector3(objeto.position.x+6f, altura, transform.position.z);

        // Actualizar la posici�n de la c�mara
        transform.position = nuevaPosicion;
    }
}
