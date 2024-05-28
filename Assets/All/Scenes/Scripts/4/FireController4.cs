using UnityEngine;

public class FireController4 : MonoBehaviour
{
    // Definimos las posiciones objetivo en Y
    private float[] posicionesY = { -2f, 0f, 2f };

    void Start()
    {
        // Llamamos a la función para iniciar el movimiento automático
        InvokeRepeating("TeletransportarAleatoriamente", 0f, 4f); // Se llama a la función cada 1 segundo
    }

    // Función para teletransportar el objeto a una posición aleatoria en Y
    void TeletransportarAleatoriamente()
    {
        // Escogemos aleatoriamente una posición del array posicionesY
        int indicePosicionAleatoria = Random.Range(0, posicionesY.Length);
        float posY = posicionesY[indicePosicionAleatoria];

        // Teletransportamos el objeto a la nueva posición
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }
}
