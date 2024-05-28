using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFronts : MonoBehaviour
{
   
    private int cantidadFronts = 6; 
    public Vector3 rangoInicio; 
    public Vector3 rangoFin;
    public float distanciaMinima = 20f;
    public GameObject prefabQ;
    public GameObject prefabW;
    private int prefabsGenerados = 0; 

    private List<GameObject> frontsGenerados = new List<GameObject>(); 

    private void Start()
    {
        GenerateFronts();
    }

    void GenerateFronts()
    {
        while (prefabsGenerados < cantidadFronts)
        {
            float randomX = Random.Range(rangoInicio.x, rangoFin.x);
            Vector3 spawnPosition = new Vector3(randomX, rangoInicio.y, rangoInicio.z);

            // Comprueba la distancia mínima entre "fronts"
            bool distanciaValida = true;
            foreach (var front in frontsGenerados)
            {
                if (Vector3.Distance(spawnPosition, front.transform.position) < distanciaMinima)
                {
                    distanciaValida = false;
                    break;
                }
            }

            if (distanciaValida)
            {
                GameObject nuevoFront;

                // Alterna entre los prefabs Q y W
                if (prefabsGenerados % 2 == 0)
                {
                    nuevoFront = Instantiate(prefabQ, spawnPosition, Quaternion.identity);
                    nuevoFront.AddComponent<PrefabKey>().TeclaEsperada = KeyCode.Q;
                    Debug.Log("Generado prefabQ");
                }
                else
                {
                    nuevoFront = Instantiate(prefabW, spawnPosition, Quaternion.identity);
                    nuevoFront.AddComponent<PrefabKey>().TeclaEsperada = KeyCode.W;
                    Debug.Log("Generado prefabW");
                }
                    
                frontsGenerados.Add(nuevoFront);
                prefabsGenerados++;
            }
        }
    }
}