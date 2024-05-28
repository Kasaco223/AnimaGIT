using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController1 : MonoBehaviour
{
    public GameObject recyclePrefab; // Referencia al prefab Recycle
    public GameObject junkPrefab; // Referencia al prefab Junk
    public Transform objeto;
    public float minDistancia = 1f;
    public float maxDistancia = 6f;
    private float altura;

    void Start()
    {
        // Llamar a la corrutina para generar pickups repetidamente
        StartCoroutine(GenerarPickupsRepetidamente());
    }

    IEnumerator GenerarPickupsRepetidamente()
    {
        while (true)
        {
            // Generar 2 pickups
            for (int i = 0; i < 2; i++)
            {
                GenerarPickup();
            }

            // Esperar 1 segundo antes de generar el pr�ximo conjunto de pickups
            yield return new WaitForSeconds(2f);
        }
    }

    void GenerarPickup()
    {
        // Colocar el pickup en una posici�n aleatoria en X entre minDistancia y maxDistancia, y en una altura de -3 o 3
        altura = (Random.value < 0.5f) ? -3f : 3f;
        float distancia = Random.Range(objeto.position.x + minDistancia, objeto.position.x + maxDistancia);
        Vector3 posicionPickup = new Vector3(distancia, altura, 0f);

        // Instanciar el prefab adecuado aleatoriamente entre Recycle y Junk
        GameObject pickup;
        if (Random.value < 0.5f)
        {
            pickup = Instantiate(recyclePrefab, posicionPickup, Quaternion.identity);
        }
        else
        {
            pickup = Instantiate(junkPrefab, posicionPickup, Quaternion.identity);
        }

        // Iniciar la coroutine para destruir el pickup despu�s de 2 segundos
        StartCoroutine(DestruirPickup(pickup));
    }

    IEnumerator DestruirPickup(GameObject pickup)
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Si el pickup todav�a existe despu�s de 2 segundos, destruirlo
        if (pickup != null)
        {
            Destroy(pickup);
        }
    }

    public void PickupTocado()
    {
        // Este m�todo puede permanecer igual si solo quieres generar pickups adicionales en respuesta a una acci�n del jugador
        GenerarPickup();
    }
}
