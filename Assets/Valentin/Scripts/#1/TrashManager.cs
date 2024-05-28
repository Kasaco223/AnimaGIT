using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashes = new List<GameObject>();
    [SerializeField] private int difficulty;

    void Start()
    {
        difficulty = Random.Range(0, 3);
    }

    void Update()
    {
        switch (difficulty)
        {
            case 0:
                SpawnTrashes("easy");
                break;
            case 1:
                SpawnTrashes("medium");
                break;
            case 2:
                SpawnTrashes("hard");
                break;
        }
    }

    private void SpawnTrashes(string msj)
    {
        int num;
        Debug.Log(msj);

        if (msj == "easy")
            num = 12;
        else if(msj == "medium")
            num = 10;
        else
            num = 7;

        List<int> index = new List<int>(); 

        for (int i = 0; i < num; i++)
        {
            int trash = Random.Range(0, trashes.Count);

            while (index.Contains(trash) || trashes[trash] == null)
                trash = Random.Range(0, trashes.Count);

            index.Add(trash);

            DestroyImmediate(trashes[trash], true);
        }

        difficulty = 5; //esto es para que no entre al switch y haga un bucle
    }
}
