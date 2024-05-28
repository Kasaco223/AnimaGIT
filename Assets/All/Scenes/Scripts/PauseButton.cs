using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    Pause pause;

    private void Start()
    {
        pause = FindObjectOfType<Pause>(); // Encuentra el objeto Pause en la escena
        if (pause == null)
        {
            Debug.LogError("No se encontró el objeto Pause en la escena.");
        }
    }

    public void PauseMetod()
    {
        if (pause != null)
        {
            pause.PauseButton();
        }
        else
        {
            Debug.LogError("El objeto Pause no ha sido inicializado.");
        }
    }
}
