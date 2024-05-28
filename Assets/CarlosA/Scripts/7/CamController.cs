using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform objeto; // El objeto que la cámara seguirá
    private float altura; // La altura inicial de la cámara

    void Start()
    {
        // Guardar la altura inicial de la cámara
        altura = transform.position.y;
    }

    void Update()
    {
        // Crear una nueva posición para la cámara que copia la posición x del objeto
        Vector3 nuevaPosicion = new Vector3(objeto.position.x+6f, altura, transform.position.z);

        // Actualizar la posición de la cámara
        transform.position = nuevaPosicion;
    }
}
