using UnityEngine;

public class Salida2 : MonoBehaviour
{
    MasterSound masterSound;
    public bool corriente = false; // Cambiado de público a privado
    private void Start()
    {
        masterSound = FindObjectOfType<MasterSound>(); // Cambiado FindAnyObjectByType a FindObjectOfType
    }
    public void RecibirConexion(bool estado)
    {
        corriente = estado;
        if (corriente)
        {
            Debug.Log("Ganaste");
        }
        LevelMaster2.LoadRandomScene();
        LevelMaster2.lvl6 = true;
        // Llama al método PlayVictorySound directamente desde la clase MasterSound
        MasterSound.PlayVictorySound();
    }

    // Método para recibir la señal de desconexión
    public void RecibirDesconexion()
    {
        corriente = false;
        Debug.Log("Desconectado");
    }
}
