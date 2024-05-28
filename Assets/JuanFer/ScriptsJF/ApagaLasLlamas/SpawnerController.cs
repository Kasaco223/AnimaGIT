using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SpawnerController : MonoBehaviour
{
    public GameObject[] myObjects;
    private float spawnInterval;

    public int score = 0;

    public bool gameLost = false;
    public bool gameWin = false;
    public TextMeshProUGUI countdownText;
    MasterSound masterSound;
    private float countdownTime = 30f;
    private void Start()
    {
        countdownText.text = $"{Mathf.Ceil(countdownTime)}";
        masterSound = FindAnyObjectByType<MasterSound>();
        spawnInterval = Random.Range(0.65f, 0.95f);
        StartCoroutine(SpawnPrefab());
        Invoke("WinGame", countdownTime); // Invoca el método WinGame después de 30 segundos
    }
    void Update()
    {
        countdownTime -= Time.deltaTime; // Resta el tiempo transcurrido
        countdownText.text = $"{Mathf.Ceil(countdownTime)}"; // Actualiza el texto
    }

    private IEnumerator SpawnPrefab()
    {
        while (!gameLost && !gameWin)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawn = new Vector3(Random.Range(-30, 30), 1, Random.Range(-25, 25));

            GameObject spawnedObject = Instantiate(myObjects[randomIndex], randomSpawn, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void LoseGame(int score)
    {
        gameLost = true;
        //Debug.Log("Entró");
        Debug.Log("Perdiste el juego. Puntuacion final: " + score);
        MasterSound.PlayDefeatSound();
        SceneManager.LoadScene("Lose");
    }

    public void WinGame()
    {
        if (!gameLost) 
        {
            gameWin = true;
            Debug.Log("Ganaste el juego!");
        }
      
        LevelMaster2.lvl2 = true;
        MasterSound.PlayVictorySound();
        SceneManager.LoadScene("Win");
    }
}
