using UnityEngine;

public class JunkController : MonoBehaviour
{
    private PickUpController1 controladorPickup;
    private int totalPointsChange = -10;  // Cambia los puntos para restar 10
    private Master7 master;  // Crea una instancia de Master7


    void Start()
    {
        // Encuentra el ControladorPickup en la escena
        controladorPickup = FindObjectOfType<PickUpController1>();

        // Crea una instancia de Master7
        master = FindObjectOfType<Master7>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra en el trigger tiene la etiqueta "Player", informar al ControladorPickup y luego destruir este objeto
        if (other.gameObject.CompareTag("Player"))
        {
            controladorPickup.PickupTocado();
            Destroy(gameObject);

            // Llama al método UpdateScore en la instancia de Master7
            master.UpdateScore(totalPointsChange);  // Resta 10 al puntaje
        }
    }
}
