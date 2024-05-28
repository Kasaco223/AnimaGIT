using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermometroSinglton : MonoBehaviour
{
    private float time;
    private Slider slider; // Referencia directa al Slider en el mismo objeto

    private void Start()
    {
        // Obtiene el tiempo inicial del MasterTime
        time = MasterTime.remainingTime;

        // Busca el componente Slider en el mismo objeto
        slider = GetComponent<Slider>();

        // Asegúrate de que el slider esté asignado
        if (slider == null)
        {
            Debug.LogError("El Slider no está asignado en el Inspector.");
        }
    }

    private void Update()
    {
        
        // Actualiza el tiempo obtenido del MasterTime
        time = MasterTime.remainingTime;
        //Debug.Log("Time: "+time);
        // Actualiza el valor del slider
        if (slider != null)
        {
            slider.value = time/ 180f; // Escala inversa para que el slider disminuya a medida que el tiempo disminuye
           // Debug.Log(slider.value);
        }
        else
        {
            // Si no se encuentra el slider, intenta buscarlo nuevamente en la escena
            slider = FindObjectOfType<Slider>();
        }
    }
}
