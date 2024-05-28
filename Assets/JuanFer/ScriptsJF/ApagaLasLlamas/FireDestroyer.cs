using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestroyer : MonoBehaviour
{
    public static int score;
    private SpawnerController spawnerController;
    private UIApagaJF uIApagaJF;

    private void Start()
    {
        spawnerController = FindObjectOfType<SpawnerController>();
        uIApagaJF = FindObjectOfType<UIApagaJF>();

        StartCoroutine(DestroyAfterSeconds(10f));
    }

    private void OnMouseDown()
    {
        if(spawnerController.gameLost == false && spawnerController.gameLost == false)
        {
            Destroy(gameObject);
            IncrementScore();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

   
    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        //var fire.GameObject = Instantiate(spawnerController.myObjects);

        yield return new WaitForSeconds(seconds);
        if (!spawnerController.gameLost)
        {
            spawnerController.LoseGame(score);
            //Debug.Log("Perdiste el juego. Puntuación final: " + score);

            //Destroy(spawnerController.myObjects);
             
        }
    }

    /*private void Destroy(GameObject[] myObjects)
    {
        

        foreach (GameObject obj in spawnerController.myObjects)
        {
            Destroy(obj);
        }
    }*/

    private void IncrementScore()
    {
        score++;
        //Debug.Log("Puntaje: " + score);
        uIApagaJF.UpdateScore(score);
    }
}
