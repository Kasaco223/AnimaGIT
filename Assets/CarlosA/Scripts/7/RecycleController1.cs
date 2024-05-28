using UnityEngine;

public class RecycleController : MonoBehaviour
{
    private PickUpController1 controladorPickup;
    private int totalPointsChange = 10;
    private Master7 master;

    void Start()
    {
        controladorPickup = FindObjectOfType<PickUpController1>();
        master = FindObjectOfType<Master7>(); // Encuentra el script Master7 en la escena
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controladorPickup.PickupTocado(); // Llama al método PickupTocado()
            Destroy(gameObject);
            master.UpdateScore(totalPointsChange); // Llama al método UpdateScore() de Master7
        }
    }
}
