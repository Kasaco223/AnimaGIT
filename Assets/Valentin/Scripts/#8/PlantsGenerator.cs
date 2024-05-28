/*
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
*/
using UnityEngine;

public class PlantsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] plants;
    [SerializeField] float timeGeneration;
    [SerializeField] private float timeNext;
    [SerializeField] public static int difficulty;
    [SerializeField] private bool end;
    int i;
    int num;

    [SerializeField]float timer;

    void Start()
    {
        difficulty = Random.Range(0, 3);
        end = false;
        timeNext = 0f;
        i = 0;
        num = 0;
    }

    void Update()
    {
        if (timer <= 0)
        {
            switch (difficulty)
            {
                case 0:
                    SpawnEasy();
                    timeGeneration = Random.Range(1, 3f);
                    break;
                case 1:
                    SpawnMedium();
                    timeGeneration = Random.Range(0.6f, 2.5f);
                    break;
                case 2:
                    SpawnHard();
                    timeGeneration = Random.Range(0.3f, 1.5f);
                    break;
            }

            timer = timeGeneration;
        }
        else
            timer -= Time.deltaTime;
    }

    private void SpawnEasy()
    {
        int plant = Random.Range(0, plants.Length);

        num = Random.Range(3, 5);

        if (i < num)
        {
            Instantiate(plants[plant], transform.position, Quaternion.identity);
            Debug.Log("Planta No." + plant);
            i++;
        }
        else
            difficulty = 5;
    }

    private void SpawnMedium()
    {
        int plant = Random.Range(0, plants.Length);

        num = Random.Range(5, 8);

        if (i < num)
        {
            Instantiate(plants[plant], transform.position, Quaternion.identity);
            Debug.Log("Planta No." + plant);
            i++;
        }
        else
            difficulty = 5;
    }

    private void SpawnHard()
    {
        int plant = Random.Range(0, plants.Length);

        num = Random.Range(8, 10);

        if (i < num)
        {
            Instantiate(plants[plant], transform.position, Quaternion.identity);
            //Debug.Log("Planta No." + plant);
            i++;
        }
        else
            difficulty = 5;
    }
}