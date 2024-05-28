using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectRuleta : MonoBehaviour
{
    Pause pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindAnyObjectByType<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        pause.ReanudarJuego();
    }
}
