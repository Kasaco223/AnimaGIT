using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float initialTime = 600f; // 10 minutos en segundos
    public TextMeshProUGUI timerText;
    public string startSceneName = "Start";

    private float currentTime;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentTime = initialTime;
        UpdateTimerText();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Cargar la escena "Start" cuando el contador llegue a 0
            SceneManager.LoadScene(startSceneName);
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Mostrar u ocultar el contador según la escena actual
        bool showTimer = scene.name != startSceneName;
        timerText.gameObject.SetActive(showTimer);
    }
}
