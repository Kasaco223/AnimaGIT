using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Velocidad de movimiento
    public float velocidad = 5f;

    // Update se llama una vez por frame
    void Update()
    {
        // Mueve el objeto hacia la dirección positiva del eje x
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }
}
