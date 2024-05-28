using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master7 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    MasterSound masterSound;

    // Start se llama antes del primer frame
    void Start()
    {
        masterSound = FindObjectOfType<MasterSound>(); // Cambiado FindAnyObjectByType a FindObjectOfType
        // Encuentra el objeto con la etiqueta "ScoreText" en la escena
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("No se encontr� el objeto con la etiqueta 'ScoreText'. Aseg�rate de asignarla en el Inspector.");
        }
        else
        {
            // Inicializa el puntaje en el TextMeshPro
            scoreText.text = "0  / 100";
        }
    }

    public void UpdateScore(int pointsChange)
    {
        string[] parts = scoreText.text.Split('/');

        string currentScoreString = parts[0].Trim();

        // Intentar convertir la puntuaci�n actual a un entero
        if (int.TryParse(currentScoreString, out int currentScore))
        {
            // La conversi�n fue exitosa, puedes usar currentScore aqu�
            // Sumar el cambio de puntos
            currentScore += pointsChange;

            // Actualizar el puntaje en el TextMeshPro
            scoreText.text = currentScore.ToString() + " / 100";

            if (currentScore > 90)
            {
                // Llama a la funci�n LoadRandomScene() de LevelMaster2

                LevelMaster2.lvl7 = true;
                // Llama al m�todo PlayVictorySound directamente desde la clase MasterSound
                MasterSound.PlayVictorySound();
                SceneManager.LoadScene("Win");
            }
        }
    }
}
