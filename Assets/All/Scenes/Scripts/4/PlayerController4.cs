using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    // Variable para almacenar la posici�n actual del objeto
    private Vector3 posicionActual;

    // Definimos las posiciones objetivo en Y
    private float[] posicionesY = { -2f, 0f, 2f };

    // Variable para almacenar el �ndice de la posici�n actual en el array posicionesY
    private int indicePosicionActual = 1; // Comenzamos en la posici�n central (y=0)


    void Update()
    {
        posicionActual = transform.position;
        // Movimiento hacia arriba (W)
        if (Input.GetKeyDown(KeyCode.W) && indicePosicionActual < posicionesY.Length - 1)
        {
            indicePosicionActual++;
            MoverObjeto();
        }
        // Movimiento hacia abajo (S)
        else if (Input.GetKeyDown(KeyCode.S) && indicePosicionActual > 0)
        {
            indicePosicionActual--;
            MoverObjeto();
        }
    }

    // Funci�n para mover el objeto a la posici�n correspondiente en Y
    void MoverObjeto()
    {
        // Obtenemos la posici�n objetivo en Y
        float posY = posicionesY[indicePosicionActual];

        // Movemos el objeto a la nueva posici�n
        transform.position = new Vector3(posicionActual.x, posY, posicionActual.z);
    }
}
