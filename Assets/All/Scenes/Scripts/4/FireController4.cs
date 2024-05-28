using UnityEngine;

public class FireController4 : MonoBehaviour
{
    // Definimos las posiciones objetivo en Y
    private float[] posicionesY = { -2f, 0f, 2f };

    void Start()
    {
        // Llamamos a la funci�n para iniciar el movimiento autom�tico
        InvokeRepeating("TeletransportarAleatoriamente", 0f, 4f); // Se llama a la funci�n cada 1 segundo
    }

    // Funci�n para teletransportar el objeto a una posici�n aleatoria en Y
    void TeletransportarAleatoriamente()
    {
        // Escogemos aleatoriamente una posici�n del array posicionesY
        int indicePosicionAleatoria = Random.Range(0, posicionesY.Length);
        float posY = posicionesY[indicePosicionAleatoria];

        // Teletransportamos el objeto a la nueva posici�n
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }
}
