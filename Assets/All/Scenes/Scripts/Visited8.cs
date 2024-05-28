using UnityEngine;

public class Visited8 : MonoBehaviour
{
    private MasterSound masterSound;

    private void Start()
    {
        // Buscar el objeto con el script MasterSound
        masterSound = FindObjectOfType<MasterSound>();
    }

    // Método para llamar cuando el jugador completa la escena 8
    public void OnScene8Completed()
    {
        // Verificar si se encontró el script MasterSound
        if (masterSound != null)
        {
            // Marcar la escena 8 como visitada
           // masterSound.MarkScene8Visited();
        }
        else
        {
            Debug.LogWarning("MasterSound script not found!");
        }
    }
}
