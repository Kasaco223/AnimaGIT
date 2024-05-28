using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIApagaJF : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI conditionText;
    [SerializeField] private GameObject MenuBack;
    private TermometroScript termometroScript;

    private SpawnerController spawnerController;

    public int score = 0;




    // Start is called before the first frame update
    private void Awake()
    {
        spawnerController = FindObjectOfType<SpawnerController>();
        termometroScript = FindObjectOfType<TermometroScript>();

        //spawnerController.score = scoreTxt;

        //LoseText.SetActive(false);
        conditionText.text = " ";
        MenuBack.SetActive(false);
    }



    void Update()
    {

        if (spawnerController.gameLost == true)
        {
            MasterSound.PlayDefeatSound();
            LevelMaster2.LoadRandomScene();
            conditionText.text = "Perdiste Mono";
            MenuBack.SetActive(true);
            termometroScript.DesactivarTemporizador();
        }
        else if (spawnerController.gameWin == true)
        {
            LevelMaster2.lvl2 = true;
            MasterSound.PlayVictorySound();
            LevelMaster2.LoadRandomScene();
            conditionText.text = "Ganaste belleza <3 ";
            MenuBack.SetActive(true);
           // termometroScript.DesactivarTemporizador();
        }

    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
