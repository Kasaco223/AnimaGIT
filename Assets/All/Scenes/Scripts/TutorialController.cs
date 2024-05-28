using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private Pause pauseScript;

    private void Start()
    {
        pauseScript = FindObjectOfType<Pause>();
        pauseScript.PauseButton();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Si se presiona click en la pantalla
        {
            if (pauseScript != null)
            {
                // Despausar el juego y destruir este objeto
                pauseScript.PauseButton();
                //Destroy(gameObject);
            }
            else
            {
                Debug.LogError("El script Pause no está asignado en TutorialController.");
            }
        }
    }
}
