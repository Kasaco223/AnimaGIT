using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController2 : MonoBehaviour
{
    public GameObject prefab; // Referencia al prefab
    public Transform objeto;
    public float minDistancia = 1f;
    public float maxDistancia = 6f;
    private float altura;
    private float distancia;

    void Start()
    {
        GenerarPickup();
    }

    void GenerarPickup()
    {
        // Colocar el pickup en una posición aleatoria en X entre minDistancia y maxDistancia, y en una altura de -3 o 3
        altura = (Random.value < 0.5f) ? -3f : 3f;
        distancia = Random.Range(objeto.position.x + minDistancia, objeto.position.x + maxDistancia);
        Vector3 posicionPickup = new Vector3(distancia, altura, 0f);

        // Instanciar un nuevo pickup
        GameObject pickup = Instantiate(prefab, posicionPickup, Quaternion.identity);

        // Iniciar la coroutine para destruir el pickup después de 2 segundos
        StartCoroutine(DestruirPickup(pickup));
    }

    IEnumerator DestruirPickup(GameObject pickup)
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Si el pickup todavía existe después de 2 segundos, destruirlo y generar uno nuevo
        if (pickup != null)
        {
            Destroy(pickup);
            GenerarPickup();
        }
    }

    public void PickupTocado()
    {
        // Cuando el pickup es tocado por el jugador, esperar 2 segundos y luego generar un nuevo pickup
        StartCoroutine(EsperarYGenerarPickup());
    }

    IEnumerator EsperarYGenerarPickup()
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Generar un nuevo pickup
        GenerarPickup();
    }
}
