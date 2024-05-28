using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public MasterSound masterSound;

    private void Start()
    {
        // Aseg�rate de que hay un componente MasterSound adjunto al objeto MasterSound
        if (masterSound == null)
        {
            masterSound = FindObjectOfType<MasterSound>();
            if (masterSound == null)
            {
                Debug.LogError("No MasterSound component found in the scene.");
            }
        }
    }

    private void Update()
    {
        // Verificar si se hizo clic en el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            // Reproducir el sonido del clic del rat�n
            masterSound.PlayMouseClickSound();
        }
    }
}
