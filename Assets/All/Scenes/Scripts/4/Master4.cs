using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Master4 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int pointsPerSecond = 5; // Cambiado a int

    private GameObject[] objectiveObjects;
    private float elapsedTime = 0f;
    private int totalPointsChange = 0; // Cambiado a int

    public AudioSource audioSource;
    public AudioClip extintor;

    private void Start()
    {
        audioSource.PlayOneShot(extintor);

        // Buscar todos los objetos con el tag "Objective"
        objectiveObjects = GameObject.FindGameObjectsWithTag("Objective");
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 0.5f) // Solo cambiar los puntos cada segundo
        {
            elapsedTime = 0f; // Reiniciar el tiempo

            // Reiniciar el cambio total de puntos
            totalPointsChange = 0;

            // Verificar si hay al menos dos objetos Objective
            if (objectiveObjects.Length >= 2)
            {
                float yPos1 = objectiveObjects[0].transform.position.y;
                float yPos2 = objectiveObjects[1].transform.position.y;

                // Si los objetos están a diferentes alturas en Y
                if (!Mathf.Approximately(yPos1, yPos2))
                {
                    audioSource.volume = 0;
                    totalPointsChange = -pointsPerSecond; // Cambiado a int
                }
                else // Si los objetos están en las mismas alturas en Y
                {
                    audioSource.volume = 1;
                    totalPointsChange = pointsPerSecond; // Cambiado a int
                }
            }

            // Actualizar el puntaje en el TextMeshPro
            UpdateScore(totalPointsChange);
        }
    }

    private void UpdateScore(int pointsChange)
    {
        string[] parts = scoreText.text.Split('/');

        string currentScoreString = parts[0].Trim();

        // Intentar convertir la puntuación actual a un entero
        if (int.TryParse(currentScoreString, out int currentScore))
        {
            // La conversión fue exitosa, puedes usar currentScore aquí
            // Sumar el cambio de puntos
            currentScore += pointsChange;

            // Actualizar el puntaje en el TextMeshPro
            scoreText.text = currentScore.ToString() + " / 70";

            // Verificar si se alcanzó la puntuación requerida para la victoria
            if (currentScore > 60)
            {
                LevelMaster2.lvl4 = true;
                MasterSound.PlayVictorySound();
                SceneManager.LoadScene("Win");
            }
        }
        else
        {
            // La conversión falló, maneja este caso de acuerdo a tus necesidades
            Debug.LogError("El texto del puntaje no es un número válido.");
        }
    }
}
