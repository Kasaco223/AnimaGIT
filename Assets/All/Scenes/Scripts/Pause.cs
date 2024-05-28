using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool juegoPausado = false;
    public static bool pausa = false;
    public Canvas canvas; // Referencia al canvas que deseas activar/desactivar
    MasterTime masterTime;
    private void Start()
    {
        masterTime = FindAnyObjectByType<MasterTime>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Hace que este objeto persista en todas las escenas
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) // Verifica si se ha presionado la tecla "P"
        {
            PauseButton();
        }
        if (juegoPausado == false)
        {
            MasterTime.timerStarted = true;
        }
        else { MasterTime.timerStarted = false; }
    }

    public void PauseButton()
    {
        if (juegoPausado)
            ReanudarJuego();
        else
            PausarJuego();
    }

    public void PausarJuego()
    {
        pausa = true;
        juegoPausado = true;
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true); // Activa el canvas
        // Aquí puedes mostrar tu menú de pausa o realizar otras acciones
    }

    public void ReanudarJuego()
    {
        pausa = false; // Debes establecer pausa como false al reanudar el juego
        juegoPausado = false;
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false); // Desactiva el canvas
        // Aquí puedes ocultar el menú de pausa o realizar otras acciones
    }
    public void Home()
    {
        SceneManager.LoadScene("Start");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ((scene.name == "Ruleta"))
        {

        }
    }
}

