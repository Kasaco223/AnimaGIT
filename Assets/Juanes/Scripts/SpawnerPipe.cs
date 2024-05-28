using System.Collections;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    public float initialDelay = 2f;
    public float spawnInterval = 2f;
    public GameObject obstaculo;
    public float minY = 0.31f; // Altura m�nima permitida para generar el obst�culo
    public float maxY = 1.85f; // Altura m�xima permitida para generar el obst�culo

    private bool isGenerating = false;

    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        Debug.Log("Esperando tiempo inicial antes de comenzar la generaci�n.");
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Comenzando generaci�n de obst�culos.");
        isGenerating = true;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (isGenerating)
        {
            Debug.Log("Generando nuevo obst�culo.");
            GameObject newObstacle = Instantiate(obstaculo);
            float randomY = Random.Range(minY, maxY); // Generar una altura aleatoria dentro del rango especificado
            newObstacle.transform.position = transform.position + new Vector3(0, randomY, 0);
            newObstacle.name = "Obstacle_" + Time.time;
            StartCoroutine(DestroyObstacle(newObstacle, 20));
            Debug.Log("Esperando intervalo de tiempo antes de generar el pr�ximo obst�culo.");
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DestroyObstacle(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Destruyendo obst�culo: " + obstacle.name);
        Destroy(obstacle);
    }

    public void StopGenerating()
    {
        isGenerating = false;
    }
}
