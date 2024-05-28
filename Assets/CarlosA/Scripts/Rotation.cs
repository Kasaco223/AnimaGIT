using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool haSidoClickeado = false;
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip tuberia;

    private void OnMouseDown()
    {
        if (!haSidoClickeado)
        {
            // Realiza la rotación de +90 grados en el eje Z
            transform.Rotate(Vector3.forward * 90f);
            haSidoClickeado = true;
            // Reproduce el sonido desde el AudioSource
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(tuberia);
            }
        }
        else
        {
            // Si ya ha sido clickeado, sigue rotando +90 grados adicionales
            transform.Rotate(Vector3.forward * 90f);

            // Reproduce el sonido desde el AudioSource
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(tuberia);
            }
        }
    }
}
