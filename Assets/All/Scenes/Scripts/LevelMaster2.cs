using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaster2 : MonoBehaviour
{
    public Canvas canvas;
    MasterTime masterTime;
    MasterSound masterSound;
    private static LevelMaster2 instance;
    private static List<string> visitedScenes = new List<string>();

    private bool lvlBool1 = false;
    private bool lvlBool2 = false;
    private bool lvlBool3 = false;
    private bool lvlBool4 = false;
    private bool lvlBool5 = false;
    private bool lvlBool6 = false;
    private bool lvlBool7 = false;
    private bool lvlBool8 = false;

    public static int visited8;

    public static bool lvl1 = false;
    public static bool lvl2 = false;
    public static bool lvl3 = false;
    public static bool lvl4 = false;
    public static bool lvl5 = false;
    public static bool lvl6 = false;
    public static bool lvl7 = false;
    public static bool lvl8 = false;

    //public static float tiempoActual;

    private void Start()
    {
        masterTime = FindAnyObjectByType<MasterTime>();

        masterSound = FindAnyObjectByType<MasterSound>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }
    private void Update()
    {
        // Debug.Log(visitedScenes.Count);

        if (lvlBool1 == false)
        {
            if (lvl1 == true)
            {
                lvlBool1 = true;
                visitedScenes.Add("1");
                Debug.Log("Sumé el 1");
            }
        }
        if (lvlBool2 == false)
        {
            if (lvl2 == true)
            {
                lvlBool2 = true;
                visitedScenes.Add("2");
                Debug.Log("Sumé el 2");
            }
        }
        if (lvlBool3 == false)
        {
            if (lvl3 == true)
            {
                lvlBool3 = true;
                visitedScenes.Add("3");
                Debug.Log("Sumé el 3");
            }
        }
        if (lvlBool4 == false)
        {
            if (lvl4 == true)
            {
                lvlBool4 = true;
                visitedScenes.Add("4");
                Debug.Log("Sumé el 4");
            }
        }
        if (lvlBool5 == false)
        {
            if (lvl5 == true)
            {
                lvlBool5 = true;
                visitedScenes.Add("5");
                Debug.Log("Sumé el 5");
            }

        }
        if (lvlBool6 == false)
        {
            if (lvl6 == true)
            {
                lvlBool6 = true;
                visitedScenes.Add("6");
                Debug.Log("Sumé el 6");
            }
        }
        if (lvlBool7 == false)
        {
            if (lvl7 == true)
            {
                lvlBool7 = true;
                visitedScenes.Add("7");
                Debug.Log("Sumé el 7");
            }
        }
        if (lvlBool8 == false)
        {
            if (lvl8 == true)
            {
                lvlBool8 = true;
                visitedScenes.Add("8");
                Debug.Log("Sumé el 8");
            }
        }


        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            LoadRandomScene();
        }
        if (visitedScenes.Count == 8)
        {
            SceneManager.LoadScene("REWIN");

        }
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "REWIN")
        {
            visitedScenes.Clear();
        }
    }



    public static void LoadRandomScene()
    {

        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "REWIN")
        {
            SceneManager.LoadScene("REWIN");
        }
        else
        {
            // Lista de nombres de escenas
            string[] sceneNames = { "1", "2", "3", "4", "5", "6", "7", "8" };

            string randomSceneName;

            // Si aún hay escenas sin visitar, elige una aleatoriamente.
            if (visitedScenes.Count < sceneNames.Length)
            {
                do
                {
                    randomSceneName = sceneNames[Random.Range(0, sceneNames.Length)];
                    if (randomSceneName == currentSceneName && visitedScenes.Count != 7)
                    {
                        randomSceneName = sceneNames[Random.Range(0, sceneNames.Length)];
                        LoadRandomScene();
                        Debug.Log("repito");
                    }

                } while (visitedScenes.Contains(randomSceneName));

            }
            else // Si todas las escenas han sido visitadas, carga la escena "Start".
            {
                randomSceneName = "REWIN";
            }

            SceneManager.LoadScene(randomSceneName);

        }

    }




    // Esta función se llama cuando se carga una nueva escena.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Esta función se llama cuando se descarga una escena.
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Esta función se ejecuta cuando se carga una escena.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ((scene.name == "REWIN"))
        {
            MasterTime.remainingTime = 180f;
            //Destroy(gameObject);
        }
        if (scene.name == "Start") // Si la escena cargada es "Start", limpia los datos.
        {

            MasterTime.remainingTime = 180f;
            MasterTime.timerStarted = false;
            visitedScenes.Clear(); // Limpiar la lista de escenas visitadas
            // Puedes agregar aquí más código para reiniciar otros datos si es necesario
            visited8 += 1;
            // Debug.Log(visited8);
            if (visited8 > 1)
            {
                MasterSound.StopAllSounds();
                visited8 = 0;
            }
            lvl1 = false;
            lvl2 = false;
            lvl3 = false;
            lvl4 = false;
            lvl5 = false;
            lvl6 = false;
            lvl7 = false;
            lvl8 = false;
            lvlBool1 = false;
            lvlBool2 = false;
            lvlBool3 = false;
            lvlBool4 = false;
            lvlBool5 = false;
            lvlBool6 = false;
            lvlBool7 = false;
            lvlBool8 = false;
            canvas.gameObject.SetActive(false);
        }
    }
    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Chao");
    }
}