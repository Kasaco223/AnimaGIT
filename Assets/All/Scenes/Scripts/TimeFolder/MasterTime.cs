using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterTime : MonoBehaviour
{
    static public float remainingTime = 180f; // 600 segundos
    static public bool timerStarted = false; // Bandera para controlar si el temporizador ha comenzado

    void Start()
    {
        // Mantener este objeto vivo al cambiar de escena
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
       // Debug.Log(timerStarted);
        // Debug.Log(remainingTime);
        // Verificar si el temporizador ha comenzado
        if (timerStarted)
        {
            // Restar el tiempo transcurrido
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0f)
            {
                // El temporizador ha llegado a cero o menos
                // Realiza alguna acción aquí (por ejemplo, mostrar un mensaje)
                SceneManager.LoadScene("RELOSE");
                remainingTime = 180f;

            }
        }
    }

    public void StartTimer()
    {
        // Iniciar el temporizador
        timerStarted = true;
        Debug.Log("Temporizador iniciado");
    }
}
