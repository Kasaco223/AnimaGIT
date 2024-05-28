using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;
    public TextMeshProUGUI scoreText;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private int totalPointsChange = 10;
    MasterSound masterSound;
    private void Start()
    {
        masterSound = FindAnyObjectByType<MasterSound>();
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString; 
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                SetCurrentWord();
                UpdateScore(totalPointsChange);
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void UpdateScore(int pointsChange) // Cambiado a int
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
            scoreText.text = currentScore.ToString() + " / 50";
            if (currentScore > 40)
            {
                LevelMaster2.lvl5 = true;
                MasterSound.PlayVictorySound();
                SceneManager.LoadScene("Win");
            }
        }
    }

}
