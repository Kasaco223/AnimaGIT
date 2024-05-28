using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Next : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    private float countdownTime = 40f;

    void Start()
    {
        Invoke("NextThing", 40f);
    }
    void Update()
    {
        countdownTime -= Time.deltaTime; // Resta el tiempo transcurrido
        countdownText.text = $"{Mathf.Ceil(countdownTime)}"; // Actualiza el texto
    }
    // Update is called once per frame
    void NextThing()
    { 
        MasterSound.PlayDefeatSound();
        SceneManager.LoadScene("Lose");
    }
}
