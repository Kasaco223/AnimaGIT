using System.Collections;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    public float initialDelay = 2f;
    public float spawnInterval = 2f;
    public GameObject obstaculo;
    public float minY = 0.31f; // Altura mínima permitida para generar el obstáculo
    public float maxY = 1.85f; // Altura máxima permitida para generar el obstáculo

    private bool isGenerating = false;

    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        Debug.Log("Esperando tiempo inicial antes de comenzar la generación.");
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Comenzando generación de obstáculos.");
        isGenerating = true;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (isGenerating)
        {
            Debug.Log("Generando nuevo obstáculo.");
            GameObject newObstacle = Instantiate(obstaculo);
            float randomY = Random.Range(minY, maxY); // Generar una altura aleatoria dentro del rango especificado
            newObstacle.transform.position = transform.position + new Vector3(0, randomY, 0);
            newObstacle.name = "Obstacle_" + Time.time;
            StartCoroutine(DestroyObstacle(newObstacle, 20));
            Debug.Log("Esperando intervalo de tiempo antes de generar el próximo obstáculo.");
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DestroyObstacle(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Destruyendo obstáculo: " + obstacle.name);
        Destroy(obstacle);
    }

    public void StopGenerating()
    {
        isGenerating = false;
    }
}
