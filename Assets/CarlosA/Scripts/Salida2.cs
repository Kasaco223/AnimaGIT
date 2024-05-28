using UnityEngine;

public class Salida2 : MonoBehaviour
{
    MasterSound masterSound;
    public bool corriente = false; // Cambiado de p�blico a privado
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
        // Llama al m�todo PlayVictorySound directamente desde la clase MasterSound
        MasterSound.PlayVictorySound();
    }

    // M�todo para recibir la se�al de desconexi�n
    public void RecibirDesconexion()
    {
        corriente = false;
        Debug.Log("Desconectado");
    }
}
