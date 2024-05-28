using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public MasterSound masterSound;

    private void Start()
    {
        // Asegúrate de que hay un componente MasterSound adjunto al objeto MasterSound
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
        // Verificar si se hizo clic en el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Reproducir el sonido del clic del ratón
            masterSound.PlayMouseClickSound();
        }
    }
}
